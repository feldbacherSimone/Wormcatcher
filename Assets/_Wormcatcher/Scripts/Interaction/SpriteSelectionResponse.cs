using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace _Wormcatcher.Scripts.Interaction
{
    public class SpriteSelectionResponse : MonoBehaviour, ISelectionResponse
    {
        //[SerializeField] private Sprite overlaySprite;
        [SerializeField] private Image curserImage;
        private Animator animator;
        public static SpriteSelectionResponse instance;

        [SerializeField] private UnityEvent selectEvent;
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(instance);
            }
            instance = this; 
        }

        private void Start()
        {
            curserImage.gameObject.SetActive(false);
            animator = curserImage.GetComponent<Animator>();
        }

        public void OnSelect(GameObject selected)
        {
            curserImage.gameObject.SetActive(true);
            animator.Play("EyeOpen");
            selectEvent.Invoke();
        }

        public void OnDeselect(GameObject selected)
        {
            animator.Play("EyeOpen");
            curserImage.gameObject.SetActive(false);
           
        }
        
    }
}