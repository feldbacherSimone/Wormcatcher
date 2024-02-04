using System;
using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneLoader.SwitchToMenu();
        }
    }
}
