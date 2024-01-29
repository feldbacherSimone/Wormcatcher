using System;
using System.Collections;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace _Wormcatcher.Scripts.Audio
{
  public class SinkSounds : MonoBehaviour
  {
    [SerializeField] private EventReference sinkEvent;
    [SerializeField] private bool startState;
    private EventInstance instance; 
    private void Start()
    {
      instance = RuntimeManager.CreateInstance((sinkEvent));
      instance.set3DAttributes(transform.To3DAttributes());
    }

    public void ToggleSinkSound()
    {
      if (!startState)
      {
        instance.setParameterByName("TurnOffSink", 0);
        instance.start();
        startState = true; 
      }
      else
      {
        StartCoroutine(StopSink(1f));
        startState = false; 
      }
    }

    IEnumerator StopSink(float waitTime)
    {
      instance.setParameterByName("TurnOffSink", 1);
      yield return new WaitForSeconds(waitTime);
    }
  }
}
