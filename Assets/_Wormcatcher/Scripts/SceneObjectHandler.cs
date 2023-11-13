using System;
using UnityEngine;

namespace _Wormcatcher.Scripts
{
    public class SceneObjectHandler : MonoBehaviour
    {
        // TODO Alles implementieren lol 
        [SerializeField] private bool objectIsActive;
        [SerializeField] private SceneObject sceneObject;
        [SerializeField] private bool debug;

        private GameObject currentSceneObject; 
        
        public static SceneObjectHandler _instance;
        

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
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

        public void SpawnObject()
        {
            if (currentSceneObject == null)
            {
                currentSceneObject = Instantiate(sceneObject.Model, transform);
            }
            currentSceneObject.SetActive(true);
            //TODO animate model (float up) 
            sceneObject.State = true; 
            DebugPrint("SpawnObject called");
        }
        public void DespawnObject()
        {
            currentSceneObject.SetActive(false);
            sceneObject.State = false; 
            DebugPrint("DespawnObject called");
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