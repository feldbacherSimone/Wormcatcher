﻿using UnityEngine;
using UnityEngine.Events;

namespace _Wormcatcher.Scripts.Interaction
{
    public class ModelSwitcher  : InteractionObject
    {
        [SerializeField] protected bool isOn;
        [SerializeField] protected GameObject[] OnObjects;
        [SerializeField] protected GameObject[] OffObjects;

        [SerializeField] private UnityEvent interactionEvent; 
       
        protected virtual void Awake()
        {
            SwitchObjects(isOn);
        }

        protected virtual void SwitchObjects(bool switchOn)
        {
            if(OnObjects == null && OffObjects == null)
                return; DebugPrint("No GameObjects to switch!");

            foreach (GameObject obj in OnObjects)
            {
                obj.SetActive(switchOn);
            }

            foreach (GameObject obj in OffObjects)
            {
                obj.SetActive(!switchOn);
            }
            DebugPrint("Objects toggled to " + isOn);
        }


        public override void Interact()
        {
            if(!Active)
                return;

            isOn = !isOn;
            SwitchObjects(isOn);
           interactionEvent.Invoke();
        }
    }
}