using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class SliderSound : MonoBehaviour, IInitializePotentialDragHandler, IPointerUpHandler
{
    [SerializeField] private EventReference sliderSound;
    private EventInstance instance; 
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        instance = RuntimeManager.CreateInstance(sliderSound);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        instance.stop(STOP_MODE.IMMEDIATE); 
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        instance.start();
    }
}
