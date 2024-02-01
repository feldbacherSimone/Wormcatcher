using System;
using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using UnityEngine;

public class BackroomTrigger : MonoBehaviour
{
    [SerializeField] private bool playerInRange;

    [SerializeField] private GameObject[] bedroom;
    [SerializeField] private GameObject[] backrooms;

    [SerializeField] private Transform playerTransform;

    [SerializeField] private Vector3 desiredPlayerScale;
    [SerializeField] private ToggleAnimation fridgeAnimator;

    [SerializeField] private float shrinkSpeed = 1; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; 
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; 
        }
    }

    public void ToggleBackrooms()
    {
        if (!playerInRange || !PlayerData.GetActionValue(PlayerAction.FinishV4Dialogue)) return;

        foreach (var gObject in bedroom)
        {
            gObject.SetActive(false);
        }

        foreach (var gObject in backrooms)
        {
            gObject.SetActive(true);
        }
        fridgeAnimator.Active = false;
        StartCoroutine(ShrinkPlayer(shrinkSpeed));
    }

    IEnumerator ShrinkPlayer(float speed)
    {
        while (Vector3.Distance(playerTransform.localScale, desiredPlayerScale) > 0.01)
        {
            playerTransform.localScale =
                Vector3.MoveTowards(playerTransform.localScale, desiredPlayerScale, speed / 100);
            yield return null; 
        }
        
    }
}
