using System;
using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts.Audio;
using FMOD;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Debug = UnityEngine.Debug;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public enum walkState
{
    Walk, 
    Run, 
}

public class StepSoundManager2 : MonoBehaviour
{
    [SerializeField] private EventReference fmodEvent;
    [SerializeField] private FloorType floorType = FloorType.Concrete;
    [SerializeField] private float rayLength = 0.2f;

    public EventReference FMODEvent => fmodEvent;
    public FloorType FloorType => floorType;

    [SerializeField] private float baseReverb = 0; 
    [SerializeField] private float baseSwirling = 0;


    [SerializeField]private bool isPlaying;
    [SerializeField]private bool debug; 
    private EventInstance instance; 
    private void Start()
    {
        instance = RuntimeManager.CreateInstance(fmodEvent);
        instance.set3DAttributes(transform.To3DAttributes());
        instance.setParameterByNameWithLabel("Ground", floorType.ToString());
        instance.setParameterByName("Reverb", baseReverb);
        instance.setParameterByName("Swirling", baseSwirling);
    }

    private void Update()
    {
        if (isPlaying)
        {
            instance.set3DAttributes(transform.To3DAttributes());
        }
    }

    public void StartSteps()
    {
        if (isPlaying)
        {
            return;
        }

        StartStepsInternal(CheckGroundType(transform));
    }
    
    public void StartSteps( float reverb, float swirling, float speed)
    {
        if (isPlaying)
        {
            return;
        }
        StartStepsInternal(CheckGroundType(transform), reverb, swirling);
    }

    private void StartStepsInternal(FloorType floor, float reverb, float swirling)
    {
        if (isPlaying)
        {
            StopSteps();
        }
        instance.set3DAttributes(transform.To3DAttributes());
        instance.setParameterByNameWithLabel("Ground", floor.ToString());
        instance.setParameterByName("Reverb", reverb);
        instance.setParameterByName("Swirling", swirling);

        print(instance.start());
        isPlaying = true; 
    }

    private void StartStepsInternal(FloorType floor)
    {
        instance.set3DAttributes(transform.To3DAttributes());
        instance.setParameterByNameWithLabel("Ground", floor.ToString());
        instance.start();
        isPlaying = true; 
    }

    public void setReverb(float reverb)
    {
        instance.setParameterByName("Reverb", reverb);
    }

    public void setSwirling(float swirling)
    {
        instance.setParameterByName("Swirling", swirling);
    }
    
    public void setFootstepSpeed(walkState walkState)
    {
        instance.setParameterByNameWithLabel("FootstepsSpeed", walkState.ToString());
    }

    public void StopSteps()
    {
        instance.stop(STOP_MODE.ALLOWFADEOUT);
        isPlaying = false; 
    }
    
    private FloorType CheckGroundType(Transform startPos)
    {
        RaycastHit hit;
        
    
        if ((Physics.Raycast(startPos.position, Vector3.down, out hit, rayLength))
            && (Enum.TryParse<FloorType>(hit.collider.tag, out FloorType floorType)))
        {
            DebugPrint($"Floor Type {floorType} found");
            return floorType;
        }

        // No ground hit
        Debug.Log("No ground hit");
        return FloorType.None;
    }
    
    private void DebugPrint(String message)
    {
        if (debug)
        {
            Debug.Log(message);
        }
    }
}