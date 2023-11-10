using System;
using UnityEngine;

namespace _Wormcatcher.Scripts
{
    public class SceneObjectHandler : MonoBehaviour
    {
        // TODO Alles implementieren lol 
        [SerializeField] private bool objectIsActive;
        [SerializeField] private SceneObject sceneObject;

        public static SceneObjectHandler _sceneObjectHandler;

        private void Awake()
        {
            if (_sceneObjectHandler == null)
            {
                _sceneObjectHandler = this;
            }
            else
            {
                 Destroy(this);
            }
        }

        public bool ObjectIsActive()
        {
            objectIsActive = sceneObject.State;
            return objectIsActive;
        }
        
        
    }
}