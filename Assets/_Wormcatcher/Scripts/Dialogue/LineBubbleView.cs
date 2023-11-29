using Yarn.Unity;
using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Wormcatcher.Scripts
{
    public class LineBubbleView : DialogueViewBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private LineManager lineManager;
        [SerializeField] internal CanvasGroup canvasGroup;

        
        [SerializeField] internal bool useFadeEffect = true;


        [SerializeField] [Min(0)] internal float fadeInTime = 0.25f;


        [SerializeField] [Min(0)] internal float fadeOutTime = 0.05f;

        [SerializeField] internal TextMeshProUGUI lineText = null;
        private Image lineBackground;

        private Color backgroundColor;
        [SerializeField] private Color backgroundHighlightColor = Color.gray;
        


        [SerializeField] internal TextMeshProUGUI characterNameText = null;

        [SerializeField] internal bool useTypewriterEffect = false;


        [SerializeField] internal UnityEngine.Events.UnityEvent onCharacterTyped;


        [SerializeField] [Min(0)] internal float typewriterEffectSpeed = 0f;

        public bool UseTypewriterEffect
        {
            get => useTypewriterEffect;
            set => useTypewriterEffect = value;
        }

        public float TypewriterEffectSpeed
        {
            get => typewriterEffectSpeed;
            set => typewriterEffectSpeed = value;
        }


        [SerializeField] [Min(0)] internal float holdTime = 1f;

        [SerializeField] internal bool autoAdvance = false;

        LocalizedLine currentLine = null;

        private Boolean hideLineOnStart; // awful name 
        private bool expanded = false; 
        
        [Tooltip("Overrides the yarn commands for line expanding forcing every line to be expanded")]
        [SerializeField] private bool forceHideLineOnStart;

        public void setHideLineOnStart()
        {
            hideLineOnStart = true;
        }

        Effects.CoroutineInterruptToken currentStopToken = new Effects.CoroutineInterruptToken();
        private LocalizedLine currentDialogueLine;
        private Action dialogueLineFinished;

        private void Awake()
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
        }

        private void Reset()
        {
            canvasGroup = GetComponentInParent<CanvasGroup>();
        }

        /// <inheritdoc/>
        public override void DismissLine(Action onDismissalComplete)
        {
            currentLine = null;

            StartCoroutine(DismissLineInternal(onDismissalComplete));
        }

        private IEnumerator DismissLineInternal(Action onDismissalComplete)
        {
            // disabling interaction temporarily while dismissing the line
            // we don't want people to interrupt a dismissal
            var interactable = canvasGroup.interactable;
            canvasGroup.interactable = false;

            // If we're using a fade effect, run it, and wait for it to finish.
            if (useFadeEffect)
            {
                yield return StartCoroutine(Effects.FadeAlpha(canvasGroup, 1, 0, fadeOutTime, currentStopToken));
                currentStopToken.Complete();
            }

            //canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            // turning interaction back on, if it needs it
            canvasGroup.interactable = interactable;

            if (onDismissalComplete != null)
            {
                onDismissalComplete();
            }
        }

        /// <inheritdoc/>
        public override void InterruptLine(LocalizedLine dialogueLine, Action onInterruptLineFinished)
        {
            currentLine = dialogueLine;

            // Cancel all coroutines that we're currently running. This will
            // stop the RunLineInternal coroutine, if it's running.
            StopAllCoroutines();

            // for now we are going to just immediately show everything
            // later we will make it fade in
            lineText.gameObject.SetActive(true);
            canvasGroup.gameObject.SetActive(true);

            int length;

            if (characterNameText == null)
            {
                lineText.text = dialogueLine.TextWithoutCharacterName.Text;
                length = dialogueLine.TextWithoutCharacterName.Text.Length;
            }
            else
            {
                characterNameText.text = dialogueLine.CharacterName;
                lineText.text = dialogueLine.TextWithoutCharacterName.Text;
                length = dialogueLine.TextWithoutCharacterName.Text.Length;
            }

            // Show the entire line's text immediately.
            lineText.maxVisibleCharacters = length;

            // Make the canvas group fully visible immediately, too.
            canvasGroup.alpha = 1;

            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            onInterruptLineFinished();
        }

        public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
        {
            // Stop any coroutines currently running on this line view (for
            // example, any other RunLine that might be running)
            StopAllCoroutines();

            currentDialogueLine = dialogueLine;
            dialogueLineFinished = onDialogueLineFinished;
            LineObject currentLineObject = lineManager.addLine(currentDialogueLine.CharacterName, "");
            lineText = currentLineObject.LineTextField;
            canvasGroup = currentLineObject.CanvasGroup;
            // Begin running the line as a coroutine.

            if (forceHideLineOnStart && dialogueLine.CharacterName.Equals("PC"))
            {
                hideLineOnStart = true; 
            }
            if (hideLineOnStart)
            {
                lineText.text = currentDialogueLine.TextWithoutCharacterName.Text.Substring(0, 1) + "...";
                lineBackground = lineText.transform.parent.GetComponent<Image>();
                backgroundColor = lineBackground.color;
                lineBackground.color = backgroundHighlightColor;
                expanded = false; 
                return;
            }
            

            StartCoroutine(RunLineInternal(currentDialogueLine, dialogueLineFinished));
        }

        private IEnumerator RunLineInternal(LocalizedLine dialogueLine, Action onDialogueLineFinished)
        {
            IEnumerator PresentLine()
            {
                lineText.gameObject.SetActive(true);
                canvasGroup.gameObject.SetActive(true);

                // Hide the continue button until presentation is complete (if
                // we have one).


                if (characterNameText != null)
                {
                    // If we have a character name text view, show the character
                    // name in it, and show the rest of the text in our main
                    // text view.
                    characterNameText.text = dialogueLine.CharacterName;
                    lineText.text = dialogueLine.TextWithoutCharacterName.Text;
                }
                else
                {
                    lineText.text = dialogueLine.TextWithoutCharacterName.Text;
                }

                if (useTypewriterEffect)
                {
                    // If we're using the typewriter effect, hide all of the
                    // text before we begin any possible fade (so we don't fade
                    // in on visible text).
                    lineText.maxVisibleCharacters = int.MaxValue;
                }
                else
                {
                    // Ensure that the max visible characters is effectively
                    // unlimited.
                    lineText.maxVisibleCharacters = int.MaxValue;
                }

                // If we're using the fade effect, start it, and wait for it to
                // finish.
                if (useFadeEffect)
                {
                    yield return StartCoroutine(Effects.FadeAlpha(canvasGroup, 0, 1, fadeInTime, currentStopToken));
                    if (currentStopToken.WasInterrupted)
                    {
                        // The fade effect was interrupted. Stop this entire
                        // coroutine.
                        yield break;
                    }
                }

                // If we're using the typewriter effect, start it, and wait for
                // it to finish.
                if (useTypewriterEffect)
                {
                    // setting the canvas all back to its defaults because if we didn't also fade we don't have anything visible
                    canvasGroup.alpha = 1f;
                    canvasGroup.interactable = true;
                    canvasGroup.blocksRaycasts = true;
                    yield return StartCoroutine(
                        TextEffects.CoolerTypewriter(
                            lineText,
                            dialogueLine,
                            typewriterEffectSpeed,
                            () => onCharacterTyped.Invoke()
                        )
                        
                    );
                    
                }
                useTypewriterEffect = true; 
            }

            currentLine = dialogueLine;

            // Run any presentations as a single coroutine. If this is stopped,
            // which UserRequestedViewAdvancement can do, then we will stop all
            // of the animations at once.
            yield return StartCoroutine(PresentLine());

            currentStopToken.Complete();

            // All of our text should now be visible.
            lineText.maxVisibleCharacters = int.MaxValue;

            // Our view should at be at full opacity.
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;

            // Show the continue button, if we have one.

            // If we have a hold time, wait that amount of time, and then
            // continue.
            if (holdTime > 0)
            {
                yield return new WaitForSeconds(holdTime);
            }

            if (autoAdvance == false)
            {
                // The line is now fully visible, and we've been asked to not
                // auto-advance to the next line. Stop here, and don't call the
                // completion handler - we'll wait for a call to
                // UserRequestedViewAdvancement, which will interrupt this
                // coroutine.
                yield break;
            }

            // Our presentation is complete; call the completion handler.
            onDialogueLineFinished();
        }

        /// <inheritdoc/>
        public override void UserRequestedViewAdvancement()
        {
            // We received a request to advance the view. If we're in the middle of
            // an animation, skip to the end of it. If we're not current in an
            // animation, interrupt the line so we can skip to the next one.

            // we have no line, so the user just mashed randomly
            if (currentLine == null)
            {
                return;
            }

            // we may want to change this later so the interrupted
            // animation coroutine is what actually interrupts
            // for now this is fine.
            // Is an animation running that we can stop?
            if (currentStopToken.CanInterrupt)
            {
                // Stop the current animation, and skip to the end of whatever
                // started it.
                currentStopToken.Interrupt();
            }
            else
            {
                // No animation is now running. Signal that we want to
                // interrupt the line instead.
                requestInterrupt?.Invoke();
            }
        }


        /// <inheritdoc />
        /// <remarks>
        /// If a line is still being shown dismisses it.
        /// </remarks>
        public override void DialogueComplete()
        {
            // do we still have a line lying around?
            if (currentLine != null)
            {
                currentLine = null;
                StartCoroutine(DismissLineInternal(null));
            }
        }


        //TODO put this in a helper class what is wrong with you! 


        public void OnPointerClick(PointerEventData eventData)
        {
            if (hideLineOnStart)
            {
                lineBackground.color = backgroundColor;
                hideLineOnStart = false;
                StartCoroutine(RunLineInternal(currentDialogueLine, dialogueLineFinished));
                expanded = true;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (hideLineOnStart)
            {
                lineBackground.color = backgroundColor; 
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (hideLineOnStart && !expanded)
                lineBackground.color = backgroundHighlightColor;
        }
    }
}