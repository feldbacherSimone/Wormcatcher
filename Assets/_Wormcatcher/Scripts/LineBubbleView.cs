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
            lineManager.addLine(dialogueLine.CharacterName);
            base.RunLine(dialogueLine, onDialogueLineFinished);
        }
    }
}