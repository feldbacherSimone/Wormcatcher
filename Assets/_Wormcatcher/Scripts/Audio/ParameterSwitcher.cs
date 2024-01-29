using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class ParameterSwitcher : MonoBehaviour
{
   [SerializeField] private StudioEventEmitter eventEmitter;

   public void ChangeIntParameter(string parameterName, int value)
   {
      eventEmitter.EventInstance.setParameterByName(parameterName, value);
   }
   
   public void ToggleIntParameter(string parameterName)
   {
      eventEmitter.EventInstance.getParameterByName(parameterName, out var val);
      val = val > 0 ? 0 : 1; 
      eventEmitter.EventInstance.setParameterByName(parameterName, val);
      Debug.Log(eventEmitter.EventInstance.getParameterByName(parameterName, out var value));
      Debug.Log(value);
   }
}
