using System;
using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using UnityEngine;
using Yarn.Unity;

public class DialogueOnTriggerEnter : MonoBehaviour
{
    [SerializeField] private DialogueRunner fishDialogueRunner;
    [SerializeField] private String nodeName;

    private bool triggered; 
    private void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            fishDialogueRunner.StartDialogue(nodeName);
            triggered = true;
        }
    }

    public void TriggerDialogue()
    {
        if(triggered) return;
        fishDialogueRunner.StartDialogue(nodeName);
    }
}
