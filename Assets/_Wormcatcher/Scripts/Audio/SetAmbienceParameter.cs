using System;
using System.Diagnostics;
using UnityEngine;


namespace _Wormcatcher.Scripts.Audio
{
    public class SetAmbienceParameter : MonoBehaviour
    {
        private String parameterName = "Ambience";

        [SerializeField] private float onValue; 
      
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !String.IsNullOrEmpty(parameterName))
            {
                print($"Parameter Value is {onValue}");
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName(parameterName, onValue);
            }
        }
        
        
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && !String.IsNullOrEmpty(parameterName))
            {
               // FMODUnity.RuntimeManager.StudioSystem.setParameterByName(parameterName, 0f);
            }
        }
    }
}