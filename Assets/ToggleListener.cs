using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class ToggleListener : MonoBehaviour
{
   private StudioListener studioListener; 
   private void Awake()
   {
     
      studioListener = GetComponent<StudioListener>();
      studioListener.enabled = false;
     
      RuntimeManager.MuteAllEvents(true);
      StartCoroutine(Enable());
   }

   IEnumerator Enable()
   {
      yield return new WaitForSeconds(2);
      studioListener.enabled = true; 
      RuntimeManager.MuteAllEvents(false);
   }
}
