﻿using System;
using FMODUnity;
using UnityEngine;

namespace _Wormcatcher.Scripts.Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        private void Awake()

        { if (Instance != null)
            {
                Debug.LogError("More than one Audio Manager");
            
            }
            Instance = this;
        }

        public void PlayOneShot(EventReference sound, Vector3 worldPos)
        {
            RuntimeManager.PlayOneShot(sound, worldPos);
        }

     
    }
}
