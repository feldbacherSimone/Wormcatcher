using System;
using UnityEngine;

namespace _Wormcatcher.Scripts.Interaction.SceneObjects
{
    /**
     * Hanldes showing and hiding the a scene object 
     */
    public class SceneObjectHandler : MonoBehaviour
    {
        [SerializeField] private bool objectIsActive;
        [SerializeField] private SceneObject sceneObject;

        public SceneObject SceneObject
        {
            get => sceneObject;
            set => sceneObject = value;
        }

        [SerializeField] private bool debug;

        [SerializeField] private bool active = true;
        [SerializeField] private bool alwaysActive;

        public bool AlwaysActive
        {
            get => alwaysActive;
            set => alwaysActive = value;
        }

        public bool Active
        {
            get => active;
            set => active = value;
        }

        private GameObject currentSceneObject; 
        
        public static SceneObjectHandler _instance;
        

        // there should only ever be one scene object per scene so we can use a sigelton
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(_instance.gameObject);
                _instance = this;
            }
            else
            {
                _instance = this;
            }
        }

        public bool ObjectIsActive()
        {
            //fallback to avoid error if no scene object is found
            if (!sceneObject) return true;
            
            objectIsActive = sceneObject.State;
            return objectIsActive;
        }

        public void SpawnObject()
        {
            if (!active || sceneObject == null || Time.timeScale < 1)
            {
                return;
            }
            if (currentSceneObject == null)
            {
                currentSceneObject = Instantiate(sceneObject.Model, transform);
            }
            currentSceneObject.SetActive(true);
            //TODO animate model (float up) 
            sceneObject.State = true; 
            sceneObject.OnHold(transform.position);
            DebugPrint("SpawnObject called");
        }
        
        public void DespawnObject()
        {
            if (!active || sceneObject == null || currentSceneObject == null || alwaysActive)
            {
                return;
            }
            currentSceneObject.SetActive(false);
            sceneObject.State = false; 
            DebugPrint("DespawnObject called");
        }

        public void DestroySceneObject()
        {
            Destroy(currentSceneObject);
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