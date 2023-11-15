using UnityEngine;

namespace _Wormcatcher.Scripts
{
    public class LineObject : MonoBehaviour

    {
        private CanvasGroup canvasGroup; // to give to the line view
        private GameObject lineContainerObject;

        public CanvasGroup CanvasGroup => canvasGroup;

        public GameObject LineContainerObject => lineContainerObject;

        public LineObject(GameObject parentObject, GameObject refernce)
        {
            lineContainerObject = Instantiate(refernce, parentObject.transform);
        }
        

    }
}