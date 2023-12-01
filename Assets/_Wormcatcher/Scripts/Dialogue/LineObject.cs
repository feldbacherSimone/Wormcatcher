using _Wormcatcher.Scripts.Dialogue;
using UnityEngine;
using TMPro;

namespace _Wormcatcher.Scripts
{
    public class LineObject : MonoBehaviour

    {
        [SerializeField] private CanvasGroup canvasGroup; // to give to the line view
        [SerializeField] private GameObject lineContainerObject;
        [SerializeField] private TextMeshProUGUI lineTextField;
        [SerializeField] private LineLayout lineLayout; 

        public TextMeshProUGUI LineTextField => lineTextField;

        public CanvasGroup CanvasGroup => canvasGroup;
        public GameObject LineContainerObject => lineContainerObject;
        public LineLayout LineLayout => lineLayout;
    }
}