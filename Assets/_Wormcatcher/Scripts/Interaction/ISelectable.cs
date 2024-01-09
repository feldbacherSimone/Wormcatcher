using UnityEngine;

namespace _Wormcatcher.Scripts
{
    public interface ISelectionResponse
    {
        void OnSelect(GameObject selected);
        void OnDeselect(GameObject selected);
    }
}