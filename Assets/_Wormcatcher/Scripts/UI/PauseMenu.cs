using System;
using _Wormcatcher.Scripts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;
using Button = UnityEngine.UI.Button;
using Cursor = UnityEngine.Cursor;
using Slider = UnityEngine.UI.Slider;

namespace _Wormcatcher.Scripts.UI
{
    [Serializable]
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseScreenGameObject;
        [SerializeField] private GameObject resumeButtonObject;
        [SerializeField] private GameObject menuButtonGameObject;

        [SerializeField] private Slider mouseSensitivitySlider;
        [SerializeField] private MouseLook mouseLook;


        private PlayerInputAction playerInputAction;
        private InputAction pauseInput;
        [SerializeField] private bool gameIsPaused;


        private void Start()
        {
            SetupButtons();
            SetupSliders();
            playerInputAction = new PlayerInputAction();
            pauseInput = playerInputAction.WalkInput.PauseGame;
            pauseInput.Enable();
            if (!gameIsPaused) Resume();
            else Pause();
        }

        private void SetupButtons()
        {
            menuButtonGameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                Resume();
                Cursor.lockState = CursorLockMode.Confined;
                SceneLoader.SwitchToMenu();
            });
            resumeButtonObject.GetComponent<Button>().onClick.AddListener(Resume);
        }

        private void SetupSliders()
        {
            mouseSensitivitySlider.minValue = mouseLook.MouseSensitivityBounds[0];
            mouseSensitivitySlider.maxValue = mouseLook.MouseSensitivityBounds[1];
            mouseSensitivitySlider.value = mouseLook.MouseSensitivity;

            mouseSensitivitySlider.onValueChanged.AddListener((value) => { mouseLook.MouseSensitivity = value; });
        }

        private void Update()
        {
            if (pauseInput.triggered)
            {
                if (!gameIsPaused) Pause();
                else Resume();
            }
        }

        void Pause()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 
            playerInputAction.WalkInput.MouseLook.Disable();

            pauseScreenGameObject.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }

        void Resume()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false; 

            pauseScreenGameObject.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }
    }
}