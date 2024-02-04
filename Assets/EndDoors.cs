using System;
using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using _Wormcatcher.Scripts.Audio;
using FMODUnity;
using UnityEngine;

public class EndDoors : MonoBehaviour
{
  [SerializeField] private GameObject fishDoor;
  [SerializeField] private GameObject outsideDoor;
  private Animator fishDoorAnimator;
  private Animator outsideDoorAnimator;
  [SerializeField] private EventReference doorSound;

  [SerializeField] private GameObject endTrigger1;
  [SerializeField] private GameObject endTrigger2;
  private void Awake()
  {
    fishDoorAnimator = fishDoor.GetComponent<Animator>();
    outsideDoorAnimator = outsideDoor.GetComponent<Animator>();
    
  }

  private void OnEnable()
  {
    fishDoor.SetActive(true);
    outsideDoor.SetActive(true);
    
    fishDoorAnimator.SetTrigger("Interact");
    outsideDoorAnimator.SetBool("OpenRight", true);
    outsideDoorAnimator.SetTrigger("Interact");
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      AudioManager.Instance.PlayOneShot(doorSound, transform.position);
      int nice = PlayerData.GetStat(PlayerStat.Nice);
      int mean = PlayerData.GetStat(PlayerStat.Mean);

      if (mean < nice)
      {
        outsideDoorAnimator.SetTrigger("Interact");
        endTrigger1.SetActive(true);
      }
      else
      {
        fishDoorAnimator.SetTrigger("Interact");
        endTrigger2.SetActive(true);
      }

      GetComponent<SphereCollider>().enabled = false;
    }
  }
}
