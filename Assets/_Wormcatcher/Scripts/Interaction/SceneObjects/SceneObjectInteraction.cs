using System;
using _Wormcatcher.Scripts.Interaction;
using _Wormcatcher.Scripts.Interaction.SceneObjects;
using UnityEngine;

namespace _Wormcatcher.Scripts
{
    /// <summary>
    /// implementation of conditional interaction. Only performs interaction if the Scene object is active (held) 
    /// </summary>
    [Serializable]
    public class SceneObjectInteraction : ConditionalInteraction
    {
        protected override bool InteractionCondition()
        {
            
            DebugPrint($"{this.name} condition is {SceneObjectHandler._instance.ObjectIsActive()}");
            return SceneObjectHandler._instance.ObjectIsActive();
        }
    }
}