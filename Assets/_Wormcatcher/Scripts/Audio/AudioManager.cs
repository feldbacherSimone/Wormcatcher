﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{
  public static AudioManager instance { get;private set; } 
    
private void Awake()
    {
        if (instance != null )
        {
            Debug.LogError("There's more than one Audio Manager in the Scene. You gotta decide who will be eliminated tonight");
        }
        instance = this;
    }
    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
    RuntimeManager.PlayOneShot(sound,worldPos);
    }
}
