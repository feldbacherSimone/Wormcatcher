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
            PlayerData.Vignette1Position = i;
        }

        public void SetState()
        {
            if(!playTest) return;

            overrideSpawnPoints = false; 
            switch (testPositions)
            {
                case TestPosition.Hallway: PlayerData.Vignette1Position = 0; break;
                case TestPosition.Mudroom: PlayerData.Vignette1Position = 1; break;
                case TestPosition.Apartment: PlayerData.Vignette1Position = 2; break;
            }
        }

        private void Start()
        {
            SetState();
            CheckSpawn();
        }

        private void CheckSpawn()
        {
            if (overrideSpawnPoints) return;

            player.transform.position = spawnPositions[PlayerData.Vignette1Position].position;
            player.transform.rotation = spawnPositions[PlayerData.Vignette1Position].rotation;
            switch (PlayerData.Vignette1Position)
            {
                case 1:
                    playerMovement.DisableWalk();
                    mouseLook.SetLookAngle(100, spawnPositions[1].rotation.eulerAngles.y);
                    stepSoundManager2.setReverb(0.2f);
                    SceneObjectHandler._instance.Active = false; 
                    break;
                case 2:
                    SceneObjectHandler._instance.Active = false; 
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