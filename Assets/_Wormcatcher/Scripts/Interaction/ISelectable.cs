using UnityEngine;

namespace _Wormcatcher.Scripts.Interaction
{
    public interface ISelectionResponse
    {
        void OnSelect(GameObject selected);
        void OnDeselect(GameObject selected);
    }
}