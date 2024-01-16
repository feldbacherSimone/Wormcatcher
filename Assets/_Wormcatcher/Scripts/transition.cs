using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transition : MonoBehaviour
{
    [SerializeField] private GameObject[] titles;
    [SerializeField] private GameObject menuTitle; 
    [SerializeField] private CanvasGroup canvasGroup;

    [SerializeField] private GameObject canvas;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(TextEffects.FadeIn(canvasGroup, 2.0f, () =>
        {
            SceneLoader.LoadNextScene();
            int currentVignette = PlayerData.Vignette; 
            GameObject currentTitle = currentVignette != 0 ? titles[currentVignette] : menuTitle; 
            GameObject.Instantiate(currentTitle, canvas.transform);
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            AnimateText typewriter = FindObjectOfType<AnimateText>();
            if (typewriter != null)
            {
                // Subscribe to the onTypewriterComplete event
                typewriter.onTypewriterComplete.AddListener(() =>
                {
                    StartCoroutine(TextEffects.FadeOut(canvasGroup, 1f, () =>
                    {
                        
                        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
                    }));
                });
            }
        }));
    }

    
}
