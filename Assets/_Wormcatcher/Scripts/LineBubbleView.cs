using Yarn.Unity;
using System;
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace _Wormcatcher.Scripts
{
    
    public class LineBubbleView : LineView
    {
        [SerializeField] private LineManager lineManager; 
        
        
        public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
        {
            StopAllCoroutines();
            print($"name:{dialogueLine.CharacterName}, text: {dialogueLine.TextWithoutCharacterName.Text}");
            LineObject currentLineObject = lineManager.addLine(dialogueLine.CharacterName, dialogueLine.TextWithoutCharacterName.Text);
            //base.RunLine(dialogueLine, onDialogueLineFinished);
            StartCoroutine(RunLineInternal(dialogueLine, onDialogueLineFinished));
        }

        private IEnumerator RunLineInternal(LocalizedLine dialogueLine, Action onDialogueLineFinished)
        {
            yield return new WaitForSeconds(0.5f);
            onDialogueLineFinished();
        }
    }
}