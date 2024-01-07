using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Wormcatcher.Scripts
{
    public enum PlayerStat
    {
        Nice,
        Mean
    }
    
    public enum PlayerAction
    {
        ToggleLight,
    }

    public static class PlayerData
    {

        private static int vignette;

        public static int Vignette
        {
            get => vignette;
            set => vignette = value;
        }


        private static Dictionary<PlayerStat, int> playerStats = new Dictionary<PlayerStat, int>
        {
            {PlayerStat.Nice, 0},
            {PlayerStat.Mean, 0},
        };

        private static Dictionary<PlayerAction, bool> playerActions = new Dictionary<PlayerAction, bool>
        {
            { PlayerAction.ToggleLight, false}
        };

        public static void UpdateStat(PlayerStat stat, int amount)
        {
            playerStats[stat] += amount; 
        }

        public static void SetStat(PlayerStat stat, int amount)
        {
            playerStats[stat] = amount; 
        }
        
        public static void SetAction(PlayerAction playerAction)
        {
            playerActions[playerAction] = true; 
        }
        public static bool GetActionValue(PlayerAction playerAction)
        {
            return playerActions[playerAction]; 
        }

        public static int GetStat(PlayerStat stat)
        {
            return playerStats[stat];
        }
        
        public static void PrintAllStats()
        {
            Debug.Log("Player Stats:");
            foreach (var stat in playerStats)
            {
                Debug.Log($"{stat.Key}: {stat.Value}");
            }
            foreach (var action in playerActions)
            {
                Debug.Log($"{action.Key}: {action.Value}");
            }
        }
    }
}