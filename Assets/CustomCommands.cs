using System;
using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using UnityEngine;
using Yarn.Unity;

public class CustomCommands : MonoBehaviour
{
    [SerializeField] private DialogueRunner dialogueRunner;
    [SerializeField] private LineBubbleView lineBubbleView;
    private void Awake()
    {
        dialogueRunner.AddCommandHandler(
            "first_letter",
            ToggleFirstLetterDialogue
            );
        dialogueRunner.AddCommandHandler<float>(
            "change_speed",
            ChangeLineSpeed
        );
    }

    private void ToggleFirstLetterDialogue()
    {
        lineBubbleView.setHideLineOnStart();
    }

    private void ChangeLineSpeed(float newSpeed)
    {
        lineBubbleView.TypewriterEffectSpeed = newSpeed; 
    }
}
