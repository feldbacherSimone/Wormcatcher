using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace _Wormcatcher.Scripts.Audio
{
    public class SetSingleParameter : MonoBehaviour
    {
        private EventInstance instance;
        [SerializeField] private EventReference eventReference; 
        [SerializeField] private String parameterName;
        [SerializeField] private float onValue;
        [SerializeField] private float offValue;

        private void Start()
        {
            if(eventReference.IsNull) return;
            instance = RuntimeManager.CreateInstance(eventReference);
            instance.start(); 
        }

        public void SetParameter()
        {
            if(String.IsNullOrEmpty(parameterName) || !instance.isValid() ) return;
            Debug.Log($"Parameter{parameterName} was set to {onValue}");
            instance.setParameterByName(parameterName, onValue);
        }

        public void UnsetParameter()
        {
            if(String.IsNullOrEmpty(parameterName) ||!instance.isValid()) return;
            Debug.Log($"Parameter{parameterName} was set to {offValue}");
            instance.setParameterByName(parameterName, offValue);
        }
    }
}