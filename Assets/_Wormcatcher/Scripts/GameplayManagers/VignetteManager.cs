using _Wormcatcher.Scripts.Inputs;
using UnityEngine;

namespace _Wormcatcher.Scripts.GameplayManagers
{
    public abstract class VignetteManager : MonoBehaviour
    {
        [SerializeField] protected bool overrideSpawnPoints;
        [SerializeField] protected bool playTest;
    
        public abstract void ChangeToApartment();
        
        public void ChangePosition(int i, int vignette)
        {

            switch (vignette)
            {
                case 1: PlayerData.V1Progress = i; break;
                case 3: PlayerData.V3Progress = i; break;
            }
            Debug.Log($"Player v1 progress is {PlayerData.V1Progress}");
        }
        public bool PlayTest
        {
            get => playTest;
            set => playTest = value;
        }
        [SerializeField] protected TestPosition testPositions;
        public TestPosition TestPositions
        {
            get => testPositions;
            set => testPositions = value;
        }
        
    
    }
}