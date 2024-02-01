using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setInstanceParameter : MonoBehaviour
{
    [SerializeField] private StepSoundManager2 stepSoundManager2;
    [SerializeField] private string parameterName;
    [SerializeField] private float parameterValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stepSoundManager2.Instance.setParameterByName(parameterName, parameterValue);
        }
    }
}