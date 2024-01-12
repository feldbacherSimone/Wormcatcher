using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioOneShotCaller : MonoBehaviour
{
    public void RequestplayOneShot(EventReference sound)
    {
        AudioManager.Instance.PlayOneShot(sound, this.transform.position);
    }
}
