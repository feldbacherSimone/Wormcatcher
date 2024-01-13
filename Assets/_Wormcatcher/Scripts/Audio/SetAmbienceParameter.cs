using System;
using UnityEngine;

namespace _Wormcatcher.Scripts.Audio
{
    public class SetAmbienceParameter : MonoBehaviour
    {
        [SerializeField] private String parameterName;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !String.IsNullOrEmpty(parameterName))
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName(parameterName, 1f);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && !String.IsNullOrEmpty(parameterName))
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName(parameterName, 0f);
            }
        }
    }
}