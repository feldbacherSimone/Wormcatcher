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
        [SerializeField] private bool debug;

        [SerializeField] private bool active = true;

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
            if (!active || sceneObject == null || currentSceneObject == null)
            {
                return;
            }
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