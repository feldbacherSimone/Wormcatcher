using UnityEditor.SceneManagement;
using UnityEngine;

namespace _Wormcatcher.Scripts
{
    public abstract class InteractionObject : MonoBehaviour
    {
        private Collider collider; 
         void Reset()
         {
             collider = GetComponent<Collider>();
             if (collider == null)
             {
                 collider = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider; 
             }
         }
    }
}