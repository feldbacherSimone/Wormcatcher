using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Yarn.Unity;

namespace _Wormcatcher.Scripts
{
    public static class TextEffects 
    {
        public static IEnumerator CoolerTypewriter(TextMeshProUGUI text, LocalizedLine fullLine, float lettersPerSecond,
            Action onCharacterTyped)
        {
            int visibleCharacters = 0;

            var maxCharacters = fullLine.TextWithoutCharacterName.Text.Length;
            // Start with everything invisible
            text.text = "";


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
                    visibleCharacters += 1;
                    text.text = fullLine.TextWithoutCharacterName.Text.Substring(0, visibleCharacters);
                    onCharacterTyped?.Invoke();
                    accumulator -= secondsPerLetter;
                }

                accumulator += Time.deltaTime;

                yield return null;
            }

            // We either finished displaying everything, or were
            // interrupted. Either way, display everything now.
            text.maxVisibleCharacters = maxCharacters;
        }
    }
}