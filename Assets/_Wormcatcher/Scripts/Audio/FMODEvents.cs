using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Door Open SFX")]
    [field: SerializeField] public EventReference doorOpenSFX { get; private set; }
    [field: Header("Door Close SFX")]
    [field: SerializeField] public EventReference doorCloseSFX { get; private set; }
    [field: Header("Door Sliding Cabinet SFX")]
    [field: SerializeField] public EventReference slidingOpenSFX { get; private set; }
    [field: Header("Door Lightswitch On SFX")]
    [field: SerializeField] public EventReference lightOnSFX { get; private set; }
    [field: Header("Door Lightswitch Off SFX")]
    [field: SerializeField] public EventReference lightOffSFX { get; private set; }
    [field: Header("Door DVD pick up")]
    [field: SerializeField] public EventReference pickUpDVDSFX { get; private set; }
    [field: Header("Key pick up")]
    [field: SerializeField] public EventReference pickUpKeySFX { get; private set; }
    [field: Header("Key Door open")]
    [field: SerializeField] public EventReference keyDoorOpenSFX { get; private set; }
    [field: Header("Sink Turn on")]
    [field: SerializeField] public EventReference sinkOnSFX { get; private set; }
    [field: Header("Sink Turn off")]
    [field: SerializeField] public EventReference sinkOffSFX { get; private set; }

    public static FMODEvents instance { get; private set; }

    private void Awake()

    { 
        if (instance != null)
        {
            Debug.LogError("More than one Fmod Events in scene");
        }
        instance = this;
     }


}
