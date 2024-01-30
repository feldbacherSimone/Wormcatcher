using System;
using _Wormcatcher.Scripts.Inputs;
using _Wormcatcher.Scripts.Interaction.SceneObjects;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Wormcatcher.Scripts.GameplayManagers
{
    public class Vignette1Manager : MonoBehaviour
    {
        
        public enum TestPosition
        {
            Hallway,
            Mudroom,
            Apartment
        }

        [SerializeField] private Transform[] spawnPositions;

        [SerializeField] private GameObject player;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private MouseLook mouseLook;
        [SerializeField] private StepSoundManager2 stepSoundManager2;
        [SerializeField] private bool overrideSpawnPoints;
        [SerializeField] private bool playTest;
        [SerializeField] private SceneObjectHandler sceneObjectHandler; 
        [SerializeField] private GameObject staticCloset; 
        [SerializeField] private GameObject interactiveClost; 
    
        public bool PlayTest
        {
            get => playTest;
            set => playTest = value;
        }

        public TestPosition TestPositions
        {
            get => testPositions;
            set => testPositions = value;
        }
        
        [SerializeField] private TestPosition testPositions;

        public void ChangePosition(int i)
        {
            PlayerData.V1Progress = i;
        }

        public void SetState()
        {
            if(!playTest) return;

            overrideSpawnPoints = false; 
            switch (testPositions)
            {
                case TestPosition.Hallway: PlayerData.V1Progress = 0; break;
                case TestPosition.Mudroom: PlayerData.V1Progress = 1; break;
                case TestPosition.Apartment: PlayerData.V1Progress = 2; break;
            }
        }

        private void Start()
        {
            SetState();
            CheckSpawn();
        }

        private void Awake()
        {
            for (int i = 0; i < spawnPositions.Length; i++)
            {
                PlayerData.SetV1Position(i, spawnPositions[i]);
            }
        }

        private void CheckSpawn()
        {
            if (overrideSpawnPoints) return;

            Debug.Log($"Spawn is {PlayerData.GetV1Position(PlayerData.V1Progress)}");
            player.transform.position = PlayerData.GetV1Position(PlayerData.V1Progress).position;
            player.transform.rotation = PlayerData.GetV1Position(PlayerData.V1Progress).rotation;
            switch (PlayerData.V1Progress)
            {
                case 0:
                    for (int i = 0; i < spawnPositions.Length; i++)
                    {
                        PlayerData.SetV1Position(i, spawnPositions[i]);
                    }
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
                default:
                    break;
            }
        }

        public void ChangeToMudroom(float time)
        {
            ChangePosition(1);
            SceneLoader.SwitchScene(1);
        }

        public void ChangeToApartment()
        {
            ChangePosition(2);
            SceneLoader.SwitchScene(1);
        }
        
        
    }

  
}