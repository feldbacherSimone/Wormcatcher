using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogLerp : MonoBehaviour
{
        [SerializeField] private float lerpTime;
        [SerializeField] private bool doEasing;
        [SerializeField] private float EndFogStart;
        [SerializeField] private float EndFogEnd;
        [SerializeField] private Color EndFogCol;

        private void OnTriggerEnter(Collider other)
        {
                if (!other.CompareTag("Player")) return;
                if (RenderSettings.fogMode != FogMode.Linear){
                        Debug.LogWarning("Error! Tried to lerp wrong fog type!"); return;}

                StopAllCoroutines();
                StartCoroutine(FogLerpCoroutine());
        }

        private float EaseIn(float t)
        {
                return (t * t);
        }

        private IEnumerator FogLerpCoroutine()
        {
                float timePassed = 0;
                float BeginFogStart = RenderSettings.fogStartDistance;
                float BeginFogEnd = RenderSettings.fogEndDistance;
                Color BeginFogCol = RenderSettings.fogColor;

                while (timePassed < lerpTime)
                {
                        if (doEasing)
                        {
                                RenderSettings.fogStartDistance = Mathf.Lerp(BeginFogStart, EndFogStart, EaseIn(timePassed/lerpTime));
                                RenderSettings.fogEndDistance = Mathf.Lerp(BeginFogEnd, EndFogEnd, EaseIn(timePassed/lerpTime));
                                RenderSettings.fogColor = Color.Lerp(BeginFogCol, EndFogCol, EaseIn(timePassed/lerpTime));
                        }
                        else
                        {
                                RenderSettings.fogStartDistance = Mathf.Lerp(BeginFogStart, EndFogStart, (timePassed/lerpTime));
                                RenderSettings.fogEndDistance = Mathf.Lerp(BeginFogEnd, EndFogEnd, (timePassed/lerpTime));
                                RenderSettings.fogColor = Color.Lerp(BeginFogCol, EndFogCol, (timePassed/lerpTime));
                        }
                        
                        timePassed += Time.deltaTime;
                        yield return null;
                }

                RenderSettings.fogStartDistance = EndFogStart;
                RenderSettings.fogEndDistance = EndFogEnd;
                RenderSettings.fogColor = EndFogCol;

        }
}
