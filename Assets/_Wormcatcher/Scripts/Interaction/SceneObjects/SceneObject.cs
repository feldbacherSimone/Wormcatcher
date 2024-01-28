using _Wormcatcher.Scripts.Audio;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace _Wormcatcher.Scripts.Interaction.SceneObjects
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
        [SerializeField] private EventReference holdingSound;
        [SerializeField] private EventReference usingSound;

        private EventInstance instance; 

        public GameObject Model => model;

        [SerializeField] private bool state = true;

        public bool State
        {
            get => state;
            set => state = value;
        }

        public void OnHold(Vector3 position )
        {
            if (!holdingSound.IsNull)
            {
                AudioManager.Instance.PlayOneShot(holdingSound, position);
            }
        }
        
        
        public void OnInteraction(Vector3 position)
        {
            if (!usingSound.IsNull)
            {
                AudioManager.Instance.PlayOneShot(usingSound, position);
            }
            //TODO What happens when we use a scene object? sound?, Animation?
        }
    }
}