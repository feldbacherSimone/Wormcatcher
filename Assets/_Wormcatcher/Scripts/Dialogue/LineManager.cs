using UnityEngine;
using System.Collections.Generic;
using _Wormcatcher.Scripts.Dialogue;
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

        [SerializeField] private bool overrideLineLayout; 
        [SerializeField] float maxWidth = 77;
        [SerializeField] private float minWidth = 10;
        [SerializeField] private int minPadding = 10;
        [SerializeField] private int maxPadding = 87;
        private int count = 0;

        public void ClearLines()
        {
            foreach (var line in linesObjects)
            {
                Destroy(line);
            }
          linesObjects.Clear();
        }

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

            if (overrideLineLayout)
            {
                LineLayout lineLayout = newLineObject.GetComponent<LineLayout>();
                if(lineLayout !=null){ lineLayout.SetParamerters(maxWidth, minWidth, minPadding, maxPadding);}
            }

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