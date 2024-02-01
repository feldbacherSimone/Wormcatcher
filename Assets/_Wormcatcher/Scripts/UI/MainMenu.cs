using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace _Wormcatcher.Scripts.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button quitButton; 
        [SerializeField] private Button playButton; 
        [SerializeField] private Button settingButton; 
        [SerializeField] private Button controlsButton;

        private PlayerInputAction playerInputAction;
        private InputAction v1Switch;
        private InputAction v2Switch;
        private InputAction v3Switch;
        private InputAction v4Switch;
        private InputAction v5Switch;
        private InputAction v6Switch;

        private void Awake()
        {
            playerInputAction = new PlayerInputAction();
            playerInputAction.Enable();
            v1Switch = playerInputAction.WalkInput.V1;
            v1Switch.Enable();
            v2Switch = playerInputAction.WalkInput.V2;
            v2Switch.Enable();
            v3Switch = playerInputAction.WalkInput.V3;
            v3Switch.Enable();
            v4Switch = playerInputAction.WalkInput.V4;
            v4Switch.Enable();
            v5Switch = playerInputAction.WalkInput.V5;
            v5Switch.Enable();
            v6Switch = playerInputAction.WalkInput.V6;
            v6Switch.Enable();
        }

        private void Update()
        {
            if (v1Switch.triggered)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                SceneLoader.SwitchScene(1);
            }
            if (v2Switch.triggered)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                SceneLoader.SwitchScene(2);
            }
            if (v3Switch.triggered)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                SceneLoader.SwitchScene(3);
            }
            if (v4Switch.triggered)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                SceneLoader.SwitchScene(4);
            }
            if (v5Switch.triggered)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                SceneLoader.SwitchScene(5);
            }
            if (v6Switch.triggered)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                SceneLoader.SwitchScene(6);
            }
        }

        private void Start()
        {
            quitButton.onClick.AddListener(() =>
            {
                Application.Quit();
            });
            playButton.onClick.AddListener(() =>
            {
                PlayerData.V1Progress = 0; 
                SceneLoader.SwitchScene(1);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false; 
            });
            settingButton.onClick.AddListener(() =>
            {
                Debug.Log("settings Pressed ");
            });
            
            controlsButton.onClick.AddListener(() =>
            {
                Debug.Log("controlls Pressed ");
            });
        }
    }
}