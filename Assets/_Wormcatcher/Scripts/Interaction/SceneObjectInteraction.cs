using System;
using UnityEngine;

namespace _Wormcatcher.Scripts
{
    [Serializable]
    public class SceneObjectInteraction : ConditionalInteraction
    {
        [SerializeField] private SceneObjectHandler sceneObjectHandler;  
        protected override bool GetCondition()
        {
            return sceneObjectHandler.ObjectIsActive();
        }
    }
}