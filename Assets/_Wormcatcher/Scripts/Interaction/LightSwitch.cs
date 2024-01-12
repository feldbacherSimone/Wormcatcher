using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Wormcatcher.Scripts
{
    public class LightSwitch  : InteractionObject
    {
        [FormerlySerializedAs("light")] [SerializeField] private Light _light;
        private Boolean lightState;


        public override void Interact()
        {
            if(!Active)
                return;
            
            if(_light == null)
                return; DebugPrint("no light found");
            
            lightState = _light.enabled;
            lightState = !lightState;
            _light.enabled = lightState;
            DebugPrint("light switched!" + lightState);
        }
    }
}
