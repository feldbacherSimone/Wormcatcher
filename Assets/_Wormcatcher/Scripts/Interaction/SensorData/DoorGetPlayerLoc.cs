using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Wormcatcher.Scripts
{
    /// <summary>
    /// Very basic script that sets the direction a door should open
    /// </summary>
    public class DoorGetPlayerLoc : MonoBehaviour
    {
        [SerializeField] private bool isRightSide;
        [SerializeField] private Animator anim;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                anim.SetBool("OpenRight", !isRightSide);
            }
        }
    }
}
