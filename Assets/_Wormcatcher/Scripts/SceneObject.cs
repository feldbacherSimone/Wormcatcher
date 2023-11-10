using UnityEngine;

namespace _Wormcatcher.Scripts
{
    [CreateAssetMenu(fileName = "SceneObject", menuName = "Wormcatcher/SceneObject", order = 1)]
    public class SceneObject : ScriptableObject
    {
        [SerializeField] private GameObject model;
        [SerializeField] private bool state = true;

        public bool State
        {
            get => state;
        }

        public void SelectSceneObject()
        {
            //TODO Set state to true
            //TODO Activate model 
            //TODO animate model (float up) 
        }
        
        public  void DeselectSceneObject()
        {
            //TODO Set state to false
            //TODO animate model (float down) 
            //TODo deactivate model 

        }
        public void OnInteraction()
        {
            //TODO What happens when we use a scene object? sound?, Animation?
        }
    }
}