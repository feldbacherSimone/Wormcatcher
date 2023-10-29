using System;
using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using UnityEngine;

public class LightSwitch  : InteractionObject, IInteractable 
{
    [SerializeField] private Light light;
    private Boolean lightState;
    [SerializeField] private Boolean debug; 
    
    
    public void Interact()
    {
        if(light == null)
            return; DebugPrint("no light found");
        lightState = light.enabled;
        lightState = !lightState;
        light.enabled = lightState;
        DebugPrint("light switched!" + lightState);
    }


    public void DebugPrint(string msg)
    {
        if (debug)
        {
            Debug.Log(msg);
        }
    }
}
