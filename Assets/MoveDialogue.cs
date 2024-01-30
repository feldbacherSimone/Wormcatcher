using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDialogue : MonoBehaviour
{
    [SerializeField] private Transform endPos;
    [SerializeField] private float speed; 
    public void MoveCurrentDialogue()
    {
        StartCoroutine(MoveDialogueRoutine());
    }

    IEnumerator MoveDialogueRoutine()
    {
        while (Vector3.Distance(transform.position, endPos.position) > 0.1)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPos.position, speed);
            yield return null; 
        }

    }
}
