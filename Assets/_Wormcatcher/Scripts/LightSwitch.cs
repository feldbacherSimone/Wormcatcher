using System;
using UnityEngine;

namespace _Wormcatcher.Scripts
{
    public class LightSwitch  : InteractionObject, IInteractable 
    {
        [SerializeField] private Light light;
        private Boolean lightState;


        public void Interact()
        {
            if(light == null)
                return; DebugPrint("no light found");
            lightState = light.enabled;
            lightState = !lightState;
            light.enabled = lightState;
            DebugPrint("light switched!" + lightState);
        }


        
    }
}
