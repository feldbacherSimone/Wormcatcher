using System;
using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts.Audio;
using FMODUnity;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler
{

    [SerializeField] private EventReference clickSound;
    [SerializeField] private EventReference hoverSound;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener((() =>
        {
            AudioManager.Instance.PlayOneShot(clickSound, transform.position);
        }));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.Instance.PlayOneShot(hoverSound, transform.position);
    }
}
