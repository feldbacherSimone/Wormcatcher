using System;
using System.Collections;
using _Wormcatcher.Scripts.Audio;
using _Wormcatcher.Scripts.Inputs;
using _Wormcatcher.Scripts.Interaction.SceneObjects;
using FMODUnity;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Wormcatcher.Scripts.GameplayManagers
{
    public class Vignette3Manager : VignetteManager
    {
        [SerializeField] private Transform[] spawnPositions;

        [SerializeField] private GameObject player;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private MouseLook mouseLook;
        [SerializeField] private StepSoundManager2 stepSoundManager2;

        [SerializeField] private SceneObjectHandler sceneObjectHandler;
        [SerializeField] private GameObject staticCloset;
        [SerializeField] private GameObject interactiveClost;

        [SerializeField] private DVDInteraction[] dvdInteractions;

        [SerializeField] private EventReference tvSound;


        public void SetState()
        {
            if (!playTest) return;

            overrideSpawnPoints = false;
            switch (testPositions)
            {
                case TestPosition.Mudroom:
                    PlayerData.V3Progress = 0;
                    break;
                case TestPosition.Apartment:
                    PlayerData.V3Progress = 1;
                    break;
            }
        }

        private void Awake()
        {
            if (overrideSpawnPoints)
            {
                playerMovement.Active = true;
                return;
            }

            SetState();
            player.transform.position = spawnPositions[PlayerData.V3Progress].position;
            player.transform.rotation = spawnPositions[PlayerData.V3Progress].rotation;
            CheckSpawn();
            playerMovement.Active = true;
        }

        private void CheckSpawn()
        {
            if (overrideSpawnPoints) return;

            switch (PlayerData.V3Progress)
            {
                case 0:
                    playerMovement.DisableWalk();
                    mouseLook.SetLookAngle(100, spawnPositions[1].rotation.eulerAngles.y);
                    stepSoundManager2.setReverb(0.2f);
                    break;
                case 1:
                    SceneObjectHandler._instance.Active = false;
                    staticCloset.SetActive(true);
                    interactiveClost.SetActive(false);
                    break;
                default:
                    break;
            }
        }

        public override void ChangeToApartment()
        {
            ChangePosition(1, 3);
            SceneLoader.SwitchScene(3);
        }

        public void OnFinishDialogue(int i)
        {
            switch (i)
            {
                case 0:
                    PlayerData.SetAction(PlayerAction.FinishedDialogueV3);
                    foreach (var dvdInteraction in dvdInteractions)
                    {
                        dvdInteraction.Active = true;
                    }

                    break;
            }
        }

        public void EndVignette3()
        {
            AudioManager.Instance.PlayOneShot(tvSound, player.transform.position);
            SceneLoader.SwitchScene(4);
        }
    }
}