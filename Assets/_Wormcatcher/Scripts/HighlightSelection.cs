using System;
using UnityEngine;

namespace _Wormcatcher.Scripts
{
    public class HighlightSelection : MonoBehaviour, ISelectableObject
    {
        [SerializeField] private Outline templateOutline; 
        private Outline outline;
        [SerializeField]private Boolean debug; 
        
        public void OnSelect(GameObject selected)
        {
            outline = selected.GetComponent<Outline>();
            DebugPrint("Selected Outline " + outline);
            if(outline == null)
            {
                DebugPrint("No outline Found, Adding Outline");
                outline = selected.AddComponent(typeof(Outline)) as Outline;
            }

            outline.OutlineMode = templateOutline.OutlineMode; 
            outline.OutlineColor = templateOutline.OutlineColor; 
            outline.OutlineWidth = templateOutline.OutlineWidth; 
            DebugPrint("outline Mode" + outline.OutlineMode);
            

        }

        public void OnDeselect(GameObject selected)
        {
            DebugPrint("Delselecting Object");
            outline.OutlineWidth = 0;
            outline.OutlineMode = Outline.Mode.OutlineAll;
        }
        
        public void DebugPrint(string msg)
        {
            if (debug)
            {
                Debug.Log(msg);
            }
        }
    }
}