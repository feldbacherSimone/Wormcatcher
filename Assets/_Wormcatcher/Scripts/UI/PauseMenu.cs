using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

namespace _Wormcatcher.Scripts.UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField]private GameObject pauseScreenGameObject;

        private PlayerInputAction playerInputAction;
        private InputAction pauseInput; 
        private bool gameIsPaused;

        [SerializeField] private Button resumeButton;
        [SerializeField] private Button menuButton;

        private void Start()
        {
            playerInputAction = new PlayerInputAction();
            pauseInput = playerInputAction.WalkInput.PauseGame;
            pauseInput.Enable();
        }

        private void SetupButtons()
        {
            resumeButton.clicked += Resume;
            menuButton.clicked += () =>
            {
                SceneLoader.SwitchScene();
            };
        }
        
        private void Update()
        {
            if (pauseInput.triggered)
            {
                if(!gameIsPaused) Pause();
                else Resume();
            }
        }

        void Pause()
        {
            Cursor.lockState = CursorLockMode.None;

            pauseScreenGameObject.SetActive(true);
            Time.timeScale = 0f; 
            gameIsPaused = true; 
        }
        
        void Resume()
        {
            Cursor.lockState = CursorLockMode.Locked;

            pauseScreenGameObject.SetActive(false);
            Time.timeScale = 1f; 
            gameIsPaused = false; 
        }
    }
}