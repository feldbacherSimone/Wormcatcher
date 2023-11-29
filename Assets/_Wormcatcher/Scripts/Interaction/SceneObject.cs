using UnityEngine;

namespace _Wormcatcher.Scripts
{
    [CreateAssetMenu(fileName = "SceneObject", menuName = "Wormcatcher/SceneObject", order = 1)]
    public class SceneObject : ScriptableObject
    {
        [SerializeField] private GameObject model;

        public GameObject Model => model;

        [SerializeField] private bool state = true;

        public bool State
        {
            get => state;
            set => state = value;
        }

        
        public void OnInteraction()
        {
            //TODO What happens when we use a scene object? sound?, Animation?
        }
    }
}