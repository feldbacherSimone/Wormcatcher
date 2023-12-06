using UnityEngine;

namespace _Wormcatcher.Scripts
{
    /// <summary>
    /// Scriptable object for scene object, handles the state of the object
    /// there should be a new instance for each scene object
    /// found in _Woemcatcher/Scripts/SceneObjects
    /// </summary>
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