using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace Yarn.Unity.Generated
{
    public class WormTransitionSound : MonoBehaviour
    {
        [SerializeField] private EventReference eventReference;
        private EventInstance instance;
        private bool wormStarted; 

        private void Start()
        {
            instance = RuntimeManager.CreateInstance(eventReference);
            instance.set3DAttributes(transform.To3DAttributes());
        }

        public void ChangeSoundParameter(int i)
        {
            Debug.Log($"ChangeParameter called value: {i}");
            instance.setParameterByName("wurmSteps", i);
        }

        public void StartSound()
        {
            if(wormStarted) return;
            Debug.Log($"Sound Started");
            instance.setParameterByName("wurmSteps", 1);
            instance.start();
            wormStarted = true;
        }

        public void Stop()
        {
            Debug.Log("SoundStopped");
            instance.stop(STOP_MODE.IMMEDIATE);
        }
    }
}