using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Wormcatcher.Scripts
{
    public enum PlayerStat
    {
        Relationship,
        Happiness,
        Sanity
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
            {PlayerStat.Relationship, 0},
            {PlayerStat.Happiness, 20},
            {PlayerStat.Sanity, 100}
        };

        public static void UpdateStat(PlayerStat stat, int amount)
        {
            playerStats[stat] += amount; 
        }

        public static void SetStat(PlayerStat stat, int amount)
        {
            playerStats[stat] = amount; 
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
        }
    }
}