using System;
using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class AnimateText : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private float charactersPerSecond = 10f; 
    public UnityEvent onTypewriterComplete = new UnityEvent();
    private void Awake()
    {
        if (text == null)
        {
            text = GetComponent<TextMeshProUGUI>();
        }
    }

    private void Start()
    {
        String fullText = text.text;
        text.text = ""; // Clear the text initially
        StartCoroutine(TextEffects.AnimateTextRoutine(fullText, text, charactersPerSecond, OnLetterPlaced, OnTypewriterComplete));
    }

    private void OnTypewriterComplete()
    {
        Debug.Log("Typewriter animation complete!");
        onTypewriterComplete.Invoke();
    }

    private void OnLetterPlaced(char letter)
    {
        //Debug.Log("Letter placed: " + letter);
    }
  
}
