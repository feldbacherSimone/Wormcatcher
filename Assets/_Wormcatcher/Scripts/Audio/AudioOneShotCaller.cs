using System.Collections;
using System.Collections.Generic;
using _Wormcatcher.Scripts.Audio;
using UnityEngine;
using FMODUnity;

public class AudioOneShotCaller : MonoBehaviour
{
    [SerializeField] private EventReference sound;
    private IEnumerator playSoundDelayed;
    
    public void RequestPlayOneShot()
    {
        AudioManager.Instance.PlayOneShot(sound, this.transform.position);
    }

    public void RequestPlayDelayedOneshot(float delay)
    {
        StopCoroutine(playSoundDelayed);
        playSoundDelayed = DelayedPlayCoroutine(delay);
        StartCoroutine(playSoundDelayed);
    }

    private IEnumerator DelayedPlayCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        RequestPlayOneShot();
    }
}
