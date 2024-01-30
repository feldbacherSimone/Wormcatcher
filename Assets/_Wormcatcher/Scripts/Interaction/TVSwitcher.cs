using System.Collections;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace _Wormcatcher.Scripts.Interaction
{
    public class TVSwitcher : ModelSwitcher
    {
        [SerializeField] private EventReference tvEvent;
        private EventInstance instance; 

        private void Start()
        {
            instance = RuntimeManager.CreateInstance(tvEvent);
            instance.set3DAttributes(transform.To3DAttributes());
        }

        protected override void SwitchObjects(bool switchOn)
        {
            StartCoroutine(ToggleTV(1f, 1f, switchOn));
        }

        IEnumerator ToggleTV(float onTime, float offTime, bool switchOn)
        {
            if (switchOn)
            {
                instance.setParameterByName("TVOff", 0);
                instance.start();
                yield return new WaitForSeconds(onTime);
                base.SwitchObjects(true);
            }
            else
            {
                instance.setParameterByName("TVOff", 1);
                yield return new WaitForSeconds(offTime);
                instance.stop(STOP_MODE.ALLOWFADEOUT);
                base.SwitchObjects(false);
            }
        }
        
        private void OnDisable()
        {
            instance.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }
    
}