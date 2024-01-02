using System;
using UnityEngine;
using Yarn.Unity;

namespace _Wormcatcher.Scripts
{
    /// <summary>
    /// Defines custom commands for Dialogue files 
    /// </summary>
    public class CustomCommands : MonoBehaviour
    {
        [SerializeField] private DialogueRunner dialogueRunner;
        [SerializeField] private LineBubbleView lineBubbleView;
        private void Awake()
        {
            dialogueRunner.AddCommandHandler(
                "first_letter",
                ToggleFirstLetterDialogue
            );
            dialogueRunner.AddCommandHandler<float>(
                "change_speed",
                ChangeLineSpeed
            );
            dialogueRunner.AddCommandHandler<String, int>(
                "update_stat",
                UpdatePlayerStat
                );
        }

        
        private void ToggleFirstLetterDialogue()
        {
            lineBubbleView.setHideLineOnStart();
        }

        private void ChangeLineSpeed(float newSpeed)
        {
            lineBubbleView.TypewriterEffectSpeed = newSpeed; 
        }

        private void UpdatePlayerStat(string playerStat, int amount)
        {
            // Convert the string to PlayerStat enum (assuming you have a method to do that)
            if (Enum.TryParse<PlayerStat>(playerStat, out var parsedStat))
            {
                PlayerData.UpdateStat(parsedStat, amount);
                PlayerData.PrintAllStats();
            }
            else
            {
                Debug.LogError($"Invalid playerStat: {playerStat}");
            }
        }
    }
}
