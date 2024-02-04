using System;
using System.Collections;
using _Wormcatcher.Scripts.Inputs;
using _Wormcatcher.Scripts.Interaction.SceneObjects;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Wormcatcher.Scripts.GameplayManagers
{
    public enum TestPosition
    {
        Hallway,
        Mudroom,
        Apartment
    }

    public class Vignette1Manager : VignetteManager
    {
        [SerializeField] private Transform[] spawnPositions;

        [SerializeField] private GameObject player;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private MouseLook mouseLook;
        [SerializeField] private StepSoundManager2 stepSoundManager2;
        [SerializeField] private SceneObjectHandler sceneObjectHandler;
        [SerializeField] private GameObject staticCloset;
        [SerializeField] private GameObject interactiveClost;

        [FormerlySerializedAs("waterplane")] [SerializeField]
        private GameObject waterPlane;

        private bool iconShowed;

        [SerializeField] private Vector3 waterTopPos;

        [SerializeField] private CanvasGroup mouseIcon;
        [SerializeField] private CanvasGroup eKey;

        public void SetState()
        {
            if (!playTest) return;

            overrideSpawnPoints = false;
            switch (testPositions)
            {
                case TestPosition.Hallway:
                    PlayerData.V1Progress = 0;
                    break;
                case TestPosition.Mudroom:
                    PlayerData.V1Progress = 1;
                    break;
                case TestPosition.Apartment:
                    PlayerData.V1Progress = 2;
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
            player.transform.position = spawnPositions[PlayerData.V1Progress].position;
            player.transform.rotation = spawnPositions[PlayerData.V1Progress].rotation;
            CheckSpawn();
            playerMovement.Active = true;
        }

        private void CheckSpawn()
        {
            if (overrideSpawnPoints) return;

            switch (PlayerData.V1Progress)
            {
                case 0:
                    ShowLeftClickIcon();
                    break;
                case 1:
                    playerMovement.DisableWalk();
                    mouseLook.SetLookAngle(100, spawnPositions[1].rotation.eulerAngles.y);
                    stepSoundManager2.setReverb(0.2f);
                    SceneObjectHandler._instance.Active = false;
                    break;
                case 2:
                    SceneObjectHandler._instance.Active = false;
                    staticCloset.SetActive(true);
                    interactiveClost.SetActive(false);
                    break;
            }
        }

        public void ChangeToMudroom(float time)
        {
            ChangePosition(1, 1);
            SceneLoader.SwitchScene(1);
        }

        public override void ChangeToApartment()
        {
            ChangePosition(2, 1);
            SceneLoader.SwitchScene(1);
        }

        public void OnFinishDialogue()
        {
            PlayerData.SetAction(PlayerAction.FinishV1Dialogue);
        }

        public void CheckDishCondition()
        {
            Debug.Log($"Condition is {PlayerData.GetActionValue(PlayerAction.FinishV1Dialogue)}");
            if (PlayerData.GetActionValue(PlayerAction.FinishV1Dialogue))
            {
                Debug.Log("Ending Vignette 1");
                playerMovement.DisableWalk();
                StartCoroutine(RiseWater(0.02f));
            }
        }

        IEnumerator RiseWater(float speed)
        {
            while (Vector3.Distance(waterPlane.transform.position, waterTopPos) > 0.001)
            {
                waterPlane.transform.position =
                    Vector3.MoveTowards(waterPlane.transform.position, waterTopPos, speed * Time.deltaTime);
                yield return null;
            }

            SceneLoader.SwitchScene(2);
        }

        public void ShowLeftClickIcon()
        {
            StartCoroutine(ShowLeftClickIconInternal());
        }

        public void ShowEKeyIcon()
        {
            if (iconShowed) return;
            StartCoroutine(TextEffects.FadeIn(eKey, 2.0f, () => { StartCoroutine(TextEffects.FadeOut(eKey, 2)); }));
            iconShowed = true;
        }

        IEnumerator ShowLeftClickIconInternal()
        {
            yield return new WaitForSeconds(5);
            sceneObjectHandler.SpawnObject();
            StartCoroutine(TextEffects.FadeIn(mouseIcon, 2.0f,
                () =>
                {
                    StartCoroutine(TextEffects.FadeOut(mouseIcon, 2, () =>
                    {
                        sceneObjectHandler.DespawnObject();
                    }));
                }));
        }
    }
}