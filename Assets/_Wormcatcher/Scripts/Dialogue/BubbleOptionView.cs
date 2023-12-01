using System;
using System.Collections;
using _Wormcatcher.Scripts.Dialogue;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Yarn.Unity;

namespace _Wormcatcher.Scripts
{
    public class BubbleOptionView : UnityEngine.UI.Selectable, ISubmitHandler, IPointerClickHandler,
        IPointerEnterHandler
    {
        [SerializeField] TextMeshProUGUI text;
        [SerializeField] bool showCharacterName = false;
        [SerializeField] internal UnityEngine.Events.UnityEvent onCharacterTyped;
        [SerializeField] private LineLayout lineLayout; 
        private bool revealOnHover;

        public bool RevealOnHover
        {
            get => revealOnHover;
            set => revealOnHover = value;
        }

        public Action<DialogueOption> OnOptionSelected;

        DialogueOption _option;

        bool hasSubmittedOptionSelection = false;

        private bool expanded = false; // EXPANDED ANIIIIMATION (ja da bin ich ja da ist er auchhhhh) 

        public bool Expanded
        {
            get => expanded;
            set => expanded = value;
        }

        private bool isRevealing = false;

        public DialogueOption Option
        {
            get => _option;


            set
            {
                _option = value;

                hasSubmittedOptionSelection = false;

                // When we're given an Option, use its text and update our
                // interactibility.

                text.text = value.Line.TextWithoutCharacterName.Text.Substring(0, 1) + "...";


                interactable = value.IsAvailable;
            }
        }

        IEnumerator Layout(String text)
        {
            yield return lineLayout.SetPadding(text); //set right padding for line on the right. 
            this.text.text = text.Substring(0, 1) + "...";
        }
        
        // If we receive a submit or click event, invoke our "we just selected
        // this option" handler.
        public void OnSubmit(BaseEventData eventData)
        {
            InvokeOptionSelected();
        }

        public void InvokeOptionSelected()
        {
            // turns out that Selectable subclasses aren't intrinsically interactive/non-interactive
            // based on their canvasgroup, you still need to check at the moment of interaction
            if (!IsInteractable())
            {
                return;
            }

            // We only want to invoke this once, because it's an error to
            // submit an option when the Dialogue Runner isn't expecting it. To
            // prevent this, we'll only invoke this if the flag hasn't been cleared already.
            if (hasSubmittedOptionSelection == false)
            {
                OnOptionSelected.Invoke(Option);
                hasSubmittedOptionSelection = true;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!revealOnHover && !expanded && !isRevealing)
            {
                StartCoroutine(RevealOption());
            }
            else if(expanded)
            {
                InvokeOptionSelected();
            }
        }

        // If we mouse-over, we're telling the UI system that this element is
        // the currently 'selected' (i.e. focused) element. 
        public override void OnPointerEnter(PointerEventData eventData)
        {
            
            
            if (expanded || !revealOnHover)
            {
                base.Select();
            }
            else if (!isRevealing && RevealOnHover)
            {
                StartCoroutine(RevealOption());
            }
        }

        private IEnumerator RevealOption()
        {
            isRevealing = true;
            yield return lineLayout.SetPadding(_option.Line.TextWithoutCharacterName.Text); //set right padding for line on the right. 
            yield return StartCoroutine(TextEffects.CoolerTypewriter(text, _option.Line, 30,
                () => onCharacterTyped.Invoke()));
            expanded = true;
            isRevealing = false;
        }
    }
}