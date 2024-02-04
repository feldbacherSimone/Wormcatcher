using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace _Wormcatcher.Scripts
{
    public static class SceneLoader
    {
        private static Scene transitionScene;
        [SerializeField] private static String nextScene;
        [SerializeField] private static float fadeTime;
        private static String next;

        private static bool transitionRunning;

        public static bool TransitionRunning
        {
            get => transitionRunning;
            set => transitionRunning = value;
        }

        public static void SwitchToMenu()
        {
            next = "MainMenu";
            PlayerData.Vignette = 0; 
            SwitchSceneInternal("TransitionScene");
        }

        public static void SwitchScene(int vignette)
        {
            next = "Vignette_" + vignette;
            PlayerData.Vignette = vignette;
            SwitchSceneInternal("TransitionScene");
        }

     
        private static void SwitchSceneInternal( String transition)
        {
            if (transitionRunning)
            {
                Debug.LogWarning("There is already a transition running");
                return;
            }
            transitionRunning = true; 
            SceneManager.LoadScene(transition, LoadSceneMode.Additive);
            //SceneManager.LoadScene(next, LoadSceneMode.Additive);
        }

        public static void LoadNextScene()
        {
            SceneManager.LoadScene(next, LoadSceneMode.Additive);
        }
    }
}