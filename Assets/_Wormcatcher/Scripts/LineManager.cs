using UnityEngine;
using System.Collections.Generic;
using Yarn.Unity;
using UnityEngine.UI; 
namespace _Wormcatcher.Scripts
{
    public class LineManager : MonoBehaviour
    {
        [SerializeField] private List<LineObject> lines = new List<LineObject>();
        [SerializeField] private float maxHeight = 10;

        [SerializeField] private Transform playerLinePos;
        [SerializeField] private Transform npcLinePos;

        [SerializeField] private GameObject playerLineRef;
        [SerializeField] private GameObject npcLineRef; 

        public LineObject addLine(string name)
        {
            LineObject newLine = null;
            GameObject currentRef; 
            
            // read character name and decide where to place line
            switch (name)
            {
                case "PC": currentRef = playerLineRef; break;
                default: currentRef = npcLineRef; break;
            }
            // create new line 
            
            if (GetComponent<RectTransform>().sizeDelta.y > maxHeight)
            {
                LineObject lastLine = lines[lines.Count - 1];
                lines.Remove(lastLine);
                Destroy(lastLine.LineContainerObject);
            }
            // Insert new line 
            newLine = new LineObject(gameObject, currentRef);
            return newLine; 
        }
    }
}