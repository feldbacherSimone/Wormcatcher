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

        public static void SwitchScene(int vignette)
        {
            next = "Vignette_" + vignette;
            PlayerData.Vignette = vignette;
            SwitchScene("TransitionScene");
        }

        private static void SwitchScene( String transition)
        {
            SceneManager.LoadScene(transition, LoadSceneMode.Additive);
            //SceneManager.LoadScene(next, LoadSceneMode.Additive);
        }

        public static void LoadNextScene()
        {
            SceneManager.LoadScene(next, LoadSceneMode.Additive);
        }
    }
}