using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using TMPro;
using UnityEngine;
using Yarn.Unity;

namespace _Wormcatcher.Scripts
{
    /// <summary>
    /// Helper class for various text effects
    /// </summary>
    public static class TextEffects
    {
        public static IEnumerator CoolerTypewriter(TextMeshProUGUI text, String fullLine, float lettersPerSecond,
            Action onCharacterTyped, Action onAnimationComplete = null)
        {
            int visibleCharacters = 0;

            var maxCharacters = fullLine.Length;
            // Start with everything invisible

            //text.text = fullLine.TextWithoutCharacterName.Text;
            text.text = " ";


            // Wait a single frame to let the text component process its
            // content, otherwise text.textInfo.characterCount won't be
            // accurate
            yield return null;

            // How many visible characters are present in the text?


            // Early out if letter speed is zero, text length is zero
            if (lettersPerSecond <= 0 || maxCharacters == 0)
            {
                // Show everything and return
                text.maxVisibleCharacters = maxCharacters;
                yield break;
            }

            // Convert 'letters per second' into its inverse
            float secondsPerLetter = 1.0f / lettersPerSecond;

            var accumulator = Time.deltaTime;

            while (visibleCharacters < maxCharacters)
            {
                // We need to show as many letters as we have accumulated
                // time for.
                while (accumulator >= secondsPerLetter)
                {
                    Canvas.ForceUpdateCanvases();
                    if(visibleCharacters < fullLine.Length)
                        visibleCharacters += 1;
                    String newText = fullLine.Substring(0, visibleCharacters);
                    text.text = newText;
                    onCharacterTyped?.Invoke();
                    accumulator -= secondsPerLetter;
                }

                accumulator += Time.deltaTime;

                
                yield return null;
            }

            // We either finished displaying everything, or were
            // interrupted. Either way, display everything now.
            text.maxVisibleCharacters = maxCharacters;
            onAnimationComplete?.Invoke();
        }


        public static IEnumerator AnimateTextRoutine(string fullText, TextMeshProUGUI textComponent,
            float charactersPerSecond, Action<char> onLetterCallback, Action onCompleteCallback)
        {
            float delay = 1f / charactersPerSecond;

            for (int i = 0; i <= fullText.Length; i++)
            {
                if (i < fullText.Length)
                {
                    char letter = fullText[i];

                    // Check if the current character is a space
                    if (letter == '<')
                    {
                        if (i + 14 > fullText.Length - 1)
                        {
                            onCompleteCallback?.Invoke();
                            break;
                        }
                        textComponent.text = fullText.Substring(0, i + 14);
                        i += 14; 
                        
                        continue;
                    }
                    if (letter == ' ')
                    {
                        // Find consecutive spaces
                        int consecutiveSpaces = 0;
                        while (i + consecutiveSpaces < fullText.Length && fullText[i + consecutiveSpaces] == ' ')
                        {
                            consecutiveSpaces++;
                        }

                        // Display all consecutive spaces at the same time
                        if (consecutiveSpaces > 1)
                        {
                            textComponent.text = fullText.Substring(0, i + consecutiveSpaces);

                            i += consecutiveSpaces - 1; // Skip the consecutive spaces
                        }
                        else
                        {
                            // Display a single space
                            textComponent.text = fullText.Substring(0, i + 1);
                            onLetterCallback?.Invoke(letter);
                        }
                    }
                    else
                    {
                        // Display non-space characters
                        textComponent.text = fullText.Substring(0, i + 1);
                        onLetterCallback?.Invoke(letter);
                    }
                }
                else
                {
                    onCompleteCallback?.Invoke();
                }

                yield return new WaitForSeconds(delay);
            }
        }

        public static IEnumerator FadeOut(CanvasGroup canvasGroup, float duration, System.Action onComplete = null)
        {
            float startAlpha = canvasGroup.alpha;
            float targetAlpha = 0f;

            float startTime = Time.time;
            float elapsedTime = 0f;


            while (elapsedTime < duration)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);

                elapsedTime = Time.time - startTime;
                yield return null;
            }

            canvasGroup.alpha = targetAlpha;

            onComplete?.Invoke();
        }

        public static IEnumerator FadeIn(CanvasGroup canvasGroup, float duration, System.Action onComplete = null)
        {
            canvasGroup.alpha = 0f;
            float startAlpha = canvasGroup.alpha;
            float targetAlpha = 1f;

            float startTime = Time.time;
            float elapsedTime = 0f;


            while (elapsedTime < duration)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);

                elapsedTime = Time.time - startTime;
                yield return null;
            }

            canvasGroup.alpha = targetAlpha;

            onComplete?.Invoke();
        }
    }
}