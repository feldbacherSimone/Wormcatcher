using System;
using UnityEngine;

namespace _Wormcatcher.Scripts
{
    public class LightSwitch  : InteractionObject
    {
        [SerializeField] private Light light;
        private Boolean lightState;


        public override void Interact()
        {
            if(!Active)
                return;
            
            if(light == null)
                return; DebugPrint("no light found");
            
            lightState = light.enabled;
            lightState = !lightState;
            light.enabled = lightState;
            DebugPrint("light switched!" + lightState);
        }
    }
}
