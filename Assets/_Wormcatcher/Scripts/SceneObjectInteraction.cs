using UnityEngine;

namespace _Wormcatcher.Scripts
{
    [System.Serializable]
    public class SceneObjectInteraction : ConditionalInteraction
    {
        [SerializeField] private SceneObjectHandler sceneObjectHandler;  
        protected override bool GetCondition()
        {
            return sceneObjectHandler.ObjectIsActive;
        }
    }
}