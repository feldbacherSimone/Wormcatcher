using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Wormcatcher.Scripts.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button quitButton; 
        [SerializeField] private Button playButton; 
        [SerializeField] private Button settingButton; 
        [SerializeField] private Button controlsButton;

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