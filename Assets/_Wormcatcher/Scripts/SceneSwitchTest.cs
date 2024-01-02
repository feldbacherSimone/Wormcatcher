using System;
using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using UnityEngine;

public class SceneSwitchTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Destroy(this.gameObject);
            //Destroy(other.transform.parent.gameObject);
            SceneLoader.SwitchScene(2);
        }
    }
}
