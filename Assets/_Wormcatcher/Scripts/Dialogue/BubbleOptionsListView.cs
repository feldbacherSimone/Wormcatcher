using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Yarn.Unity;
using UnityEngine;

namespace _Wormcatcher.Scripts
{
    /// <summary>
    /// Displays dialogue option unsing multible BubbleOptionViews 
    /// </summary>
    public class BubbleOptionsListView : DialogueViewBase
    {
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] private LineBubbleView lineBubbleView;

        [SerializeField] BubbleOptionView optionViewPrefab;

        [SerializeField] float fadeTime = 0.1f;

        [SerializeField] bool showUnavailableOptions = false;

        [SerializeField] private bool revealOnHover;

        // A cached pool of OptionView objects so that we can reuse them
        List<BubbleOptionView> optionViews = new List<BubbleOptionView>();

        // The method we should call when an option has been selected.
        Action<int> OnOptionSelected;

        // The line we saw most recently.
        LocalizedLine lastSeenLine;


        public void Start()
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        public void Reset()
        {
            canvasGroup = GetComponentInParent<CanvasGroup>();
        }


        public override void RunOptions(DialogueOption[] dialogueOptions, Action<int> onOptionSelected)
        {
            // Hide all existing option views
            foreach (var optionView in optionViews)
            {
                optionView.gameObject.SetActive(false);
            }

            // If we don't already have enough option views, create more
            while (dialogueOptions.Length > optionViews.Count)
            {
                var optionView = CreateNewOptionView();
                optionView.gameObject.SetActive(false);
            }

            // Set up all of the option views
            int optionViewsCreated = 0;

            for (int i = 0; i < dialogueOptions.Length; i++)
            {
                var optionView = optionViews[i];
                var option = dialogueOptions[i];

                if (option.IsAvailable == false && showUnavailableOptions == false)
                {
                    // Don't show this option.
                    continue;
                }

                optionView.Expanded = false;
                optionView.RevealOnHover = revealOnHover;
                optionView.gameObject.SetActive(true);
                optionView.Option = option;


                // The first available option is selected by default
                if (optionViewsCreated == 0)
                {
                    optionView.Select();
                }

                optionViewsCreated += 1;
            }


            // Note the delegate to call when an option is selected
            OnOptionSelected = onOptionSelected;

            // Fade it all in
            StartCoroutine(Effects.FadeAlpha(canvasGroup, 0, 1, fadeTime));

            BubbleOptionView CreateNewOptionView()
            {
                var optionView = Instantiate(optionViewPrefab);
                optionView.transform.SetParent(transform, false);
                optionView.transform.SetAsLastSibling();

                optionView.OnOptionSelected = OptionViewWasSelected;
                optionViews.Add(optionView);

                return optionView;
            }

            void OptionViewWasSelected(DialogueOption option)
            {
                StartCoroutine(OptionViewWasSelectedInternal(option));
                lineBubbleView.useTypewriterEffect = false;

                IEnumerator OptionViewWasSelectedInternal(DialogueOption selectedOption)
                {
                    yield return StartCoroutine(Effects.FadeAlpha(canvasGroup, 1, 0, fadeTime));
                    OnOptionSelected(selectedOption.DialogueOptionID);


                    foreach (BubbleOptionView optionView in optionViews)
                    {
                        optionView.gameObject.SetActive(false);
                    }
                }
            }
        }

        /// <inheritdoc />
        /// <remarks>
        /// If options are still shown dismisses them.
        /// </remarks>
        public override void DialogueComplete()
        {
            // do we still have any options being shown?
            if (canvasGroup.alpha > 0)
            {
                StopAllCoroutines();
                lastSeenLine = null;
                OnOptionSelected = null;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;

                StartCoroutine(Effects.FadeAlpha(canvasGroup, canvasGroup.alpha, 0, fadeTime));
            }
        }
    }
}