using System;
using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using UnityEngine;

namespace _Wormcatcher.Scripts
{
    /// <summary>
    /// Very basic script that closes a door on leaving its radius
    /// </summary>
    public class DoorLeaveRadius : MonoBehaviour
    {
        [SerializeField] private Animator anim;
        [SerializeField] private ToggleAnimation doorMain;

        private void OnTriggerExit(Collider other)
        {
            //Player has left radius
            if (other.CompareTag("Player"))
            {
                if (!doorMain.isOpen) return;
                anim.SetTrigger("Close");
            }
        }
    }
}
