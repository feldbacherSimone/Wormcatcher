using System;
using _Wormcatcher.Scripts.Audio;
using _Wormcatcher.Scripts.Dialogue;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using TMPro;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace _Wormcatcher.Scripts
{
    /// <summary>
    /// Object containing references to a differnt components in a dialogue line, for easier access in LineManager
    /// </summary>
    public class LineObject : MonoBehaviour

    {

        [SerializeField] private EventReference talkSound; 
        [SerializeField] private EventReference hoverSound; 
        [SerializeField] private EventReference clickSound; 
        [SerializeField] private CanvasGroup canvasGroup; // to give to the line view
        [SerializeField] private GameObject lineContainerObject;
        [SerializeField] private TextMeshProUGUI lineTextField;
        [SerializeField] private LineLayout lineLayout;
        private EventInstance instance; 
        public TextMeshProUGUI LineTextField => lineTextField;

        public CanvasGroup CanvasGroup => canvasGroup;
        public GameObject LineContainerObject => lineContainerObject;
        public LineLayout LineLayout => lineLayout;

        public void StartSound()
        {
            instance = RuntimeManager.CreateInstance(talkSound);
            instance.start();
        }
        public void StopSound()
        {
            instance.stop(STOP_MODE.IMMEDIATE);
        }

        private void OnDisable()
        {
            StopSound();
        }

        public void PlayHoverSound()
        {
            AudioManager.Instance.PlayOneShot(hoverSound, transform.position);
        }
        public void PlayClickSound()
        {
            AudioManager.Instance.PlayOneShot(clickSound, transform.position);
        }
    }
}