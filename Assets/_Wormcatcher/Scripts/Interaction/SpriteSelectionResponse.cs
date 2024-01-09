using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Wormcatcher.Scripts
{
    public class SpriteSelectionResponse : MonoBehaviour, ISelectionResponse
    {
        //[SerializeField] private Sprite overlaySprite;
        [SerializeField] private Image curserImage;
        private Animator animator; 

        private void Start()
        {
            curserImage.gameObject.SetActive(false);
            animator = curserImage.GetComponent<Animator>();
        }

        public void OnSelect(GameObject selected)
        {
            curserImage.gameObject.SetActive(true);
            animator.Play("EyeOpen");
        }

        public void OnDeselect(GameObject selected)
        {
            animator.Play("Default");
            curserImage.gameObject.SetActive(false);
           
        }
    }
}