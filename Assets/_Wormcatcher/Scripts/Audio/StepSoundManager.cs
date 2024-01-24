using System;
using FMODUnity;

using UnityEngine;

namespace _Wormcatcher.Scripts.Audio
{
    public enum FloorType
    {
        Carpet,
        Tiles,
        Wood,
        Concrete,
        None
    }

    [Serializable]
    public class StepSound
    {
        [SerializeField] private EventReference fmodEvent;
        [SerializeField] private FloorType floorType;
        
        public EventReference FMODEvent => fmodEvent;

        public FloorType FloorType => floorType;
    }

    public class StepSoundManager : MonoBehaviour
    {
        [SerializeField] private StepSound[] stepSounds;
        [SerializeField] private EventReference currentClip; 
        
        [SerializeField] private float rayLength = 0.2f;
        private FloorType currentFloorType;
        [SerializeField] private bool debug;

        public void PlayStepSound()
        {
            DebugPrint("Playing Footstep");
            FloorType floorType = CheckGroundType(transform);
            if (currentFloorType != null && floorType != currentFloorType)
            {
                getMatchingSound(floorType);
                currentFloorType = floorType; 
            }
            AudioManager.Instance.PlayOneShot(currentClip, transform.position );
            
        }

        private void getMatchingSound(FloorType floorType)
        {
            foreach (StepSound stepSound in stepSounds)
            {
                if (stepSound.FloorType.ToString() == floorType.ToString())
                {
                    currentClip = stepSound.FMODEvent;
                }
            }
            
            DebugPrint($"No StepSound found for Floor tyoe {floorType}, playing old clip.");
        }
    
        private FloorType CheckGroundType(Transform startPos)
        {
            RaycastHit hit;
            if ((Physics.Raycast(startPos.position, Vector3.down, out hit, rayLength))
                && (Enum.TryParse<FloorType>(hit.collider.tag, out FloorType floorType)))
            {
                DebugPrint($"Floor Type {floorType} found");
                return floorType;
            }

            // No ground hit
            Debug.Log("No ground hit");
            return FloorType.None;
        }

        private void DebugPrint(String message)
        {
            if (debug)
            {
                Debug.Log(message);
            }
        }
    }
}