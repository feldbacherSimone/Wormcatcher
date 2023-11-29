using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keepTextInLine : MonoBehaviour
{

    [SerializeField] private float maxWidth; 
    [SerializeField] private float minWidth; 
    [SerializeField] private float maxPadding = 78; 
    [SerializeField] private float minPadding = 21; 

    private RectTransform backgroundRectTransform;
    private HorizontalLayoutGroup horizontalLayoutGroup;
    private float lastWidth; 
    // Start is called before the first frame update
    void Start()
    {
        backgroundRectTransform = transform.GetChild(0).GetComponent<RectTransform>();
        horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
        lastWidth = backgroundRectTransform.rect.width; 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Math.Abs(backgroundRectTransform.rect.width - lastWidth) > 0.1)
        {
            lastWidth = backgroundRectTransform.rect.width;
            float currentWithFrac = (lastWidth-minWidth) / (maxWidth - minWidth);
            horizontalLayoutGroup.padding.left = Mathf.RoundToInt(Mathf.Lerp(maxPadding, minPadding, currentWithFrac));
        }
    }
}
