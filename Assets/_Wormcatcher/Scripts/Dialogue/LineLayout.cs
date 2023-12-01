using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Wormcatcher.Scripts.Dialogue
{
    public class LineLayout : MonoBehaviour
    {
        [SerializeField] float maxWidth = 77;
        [SerializeField] private float minWidth = 10;
        [SerializeField] private int minPadding = 21;
        [SerializeField] private int maxPadding = 87;

        private float currentWidth;

        [SerializeField] private TextMeshProUGUI textField;
        [SerializeField] private HorizontalLayoutGroup layoutGroup;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private RectTransform rectTransform;

        private void Start()
        {
            rectTransform = (rectTransform == null)
                ? transform.GetChild(0).GetComponent<RectTransform>()
                : rectTransform;
            canvasGroup = (canvasGroup == null) ? GetComponent<CanvasGroup>() : canvasGroup;
            layoutGroup = (layoutGroup == null) ? GetComponent<HorizontalLayoutGroup>() : layoutGroup;
            textField = (textField == null)
                ? transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>()
                : textField;
        }

        public IEnumerator SetPadding(String fullLine)
        {
            yield return StartCoroutine(SetPaddingInternal(fullLine));
        }

        IEnumerator SetPaddingInternal(String fullLine)
        {
            canvasGroup.alpha = 0;
            textField.text = fullLine;
            yield return null;
            currentWidth = rectTransform.rect.width;
            canvasGroup.alpha = 1;

            print($"text: {fullLine}");
            setPadding(currentWidth);
        }

        private void setPadding(float currenWidth)
        {
            if (currenWidth >= maxWidth)
                return;
            layoutGroup.childAlignment = TextAnchor.MiddleLeft;
            float currentWithFrac = (currentWidth - minWidth) / (maxWidth - minWidth);
            print($"current Width: {currenWidth}, width frac: {currentWithFrac}");
            layoutGroup.padding.left = Mathf.RoundToInt(Mathf.Lerp(maxPadding, minPadding, currentWithFrac));
        }
    }
}