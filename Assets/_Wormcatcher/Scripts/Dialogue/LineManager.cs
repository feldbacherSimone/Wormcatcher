using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;
using Yarn.Unity;
using UnityEngine.UI;

namespace _Wormcatcher.Scripts
{
    /// <summary>
    /// Adds and removes dialogue bubbles
    /// </summary>
    public class LineManager : MonoBehaviour
    {
        [FormerlySerializedAs("lines")] [SerializeField]
        private List<GameObject> linesObjects = new List<GameObject>();

        [SerializeField] private float maxHeight = 10;

        [SerializeField] private Transform playerLinePos;
        [SerializeField] private Transform npcLinePos;

        [SerializeField] private GameObject playerLineRef;
        [SerializeField] private GameObject npcLineRef;

        private int count = 0;

        public LineObject AddLine(string name, string dialogueText)
        {
            LineObject newLine = null;
            GameObject currentRef;

            // read character name and decide where to place line
            switch (name)
            {
                case "PC":
                    currentRef = playerLineRef;
                    break;
                default:
                    currentRef = npcLineRef;
                    break;
            }

            // create new line 
            GameObject newLineObject = Instantiate(currentRef, transform);
            newLine = newLineObject.GetComponent<LineObject>();
            newLineObject.transform.SetSiblingIndex(transform.childCount - 2);
            newLineObject.name = "Line_" + ++count;
           
            
            linesObjects.Add(newLineObject);

            // Delete Overflowing Lines; 
            if (GetComponent<RectTransform>().sizeDelta.y > maxHeight)
            {
                //print(linesObjects.Count);
                GameObject lastLine = linesObjects[0];
                linesObjects.Remove(lastLine);
                Destroy(lastLine);
            }

            newLine.LineTextField.text = " ";
            return newLine;
        }
    }
}