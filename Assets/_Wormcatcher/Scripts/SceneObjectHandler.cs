using UnityEngine;

namespace _Wormcatcher.Scripts
{
    public class SceneObjectHandler : MonoBehaviour
    {
        // TODO Alles implementieren lol 
        [SerializeField] private bool objectIsActive;

        public bool ObjectIsActive
        {
            get => objectIsActive;
            set => objectIsActive = value;
        }
    }
}