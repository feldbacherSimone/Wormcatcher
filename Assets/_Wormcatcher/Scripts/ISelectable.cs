using UnityEngine;

namespace _Wormcatcher.Scripts
{
    public interface ISelectableObject
    {
        void OnSelect(GameObject selected);
        void OnDeselect(GameObject selected);
    }
}