using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class DateSceneManager : MonoBehaviour
{
   [SerializeField] private float timeToStart = 1f; 
   [SerializeField] private float timeToEnd = 2f;


    [SerializeField] private DialogueRunner dialogueRunner;

    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(timeToStart);
        dialogueRunner.StartDialogue("V2");
    }

    public void EndVignette()
    {
        StartCoroutine(OnEndDialogue());
    }

    IEnumerator OnEndDialogue()
    {
        yield return new WaitForSeconds(timeToEnd);
        SceneLoader.SwitchScene(3);
    }
}
