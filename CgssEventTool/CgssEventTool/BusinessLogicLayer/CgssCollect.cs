using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CgssEventTool.BusinessLogicLayer
{
    /// <summary>
    /// The CgssCollect API
    /// Reference: https://github.com/NikuPAN/CGSS_Collect/blob/master/src/cgss_collect/CGSS_Collect.java
    /// </summary>
    public static class CgssCollect
    {
        private static readonly Dictionary<int, int> LevelStarMap = new Dictionary<int, int>()
        {
            { 0, 12 },
            { 3, 11 },
            { 11, 10 },
            { 22, 9 },
            { 37, 8 },
            { 58, 7 },
            { 85, 6 },
            { 129, 5 },
            { 197, 4 },
            { 314, 3 }
        };

        /// <summary>
        /// Gets the player's star usage according to the level
        /// </summary>
        /// <param name="playerLevel"></param>
        /// <returns></returns>
        public static int PlayerLevelToStarUsage(int playerLevel)
        {
            return LevelStarMap.LastOrDefault(lv => playerLevel > lv.Key).Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="star"></param>
        /// <param name="playerLevel"></param>
        /// <returns></returns>
        public static float StarToStaminaRecoverTimes(
            int star, 
            int playerLevel
        ) {
            if (star <= 3) return 0.0f;  // 防呆
            return (float) star / PlayerLevelToStarUsage(playerLevel);
        }

        public static double TotalStaminaToPlay(
            int star, 
            int playerLevel, 
            long autoRecoverStamina, 
            int staminaPerPlay
        ) {
            return (StarToStaminaRecoverTimes(star, playerLevel) * 10f + autoRecoverStamina) / staminaPerPlay;
        }

        /// <summary>
        /// Gets the total number of collection items
        /// </summary>
        /// <param name="star"></param>
        /// <param name="playerLevel"></param>
        /// <param name="autoRecoverStamina"></param>
        /// <param name="staminaPerPlay"></param>
        /// <param name="collectionPerPlay"></param>
        /// <returns></returns>
        public static double TotalNumCollect(
            int star, 
            int playerLevel, 
            long autoRecoverStamina, 
            int staminaPerPlay, 
            int collectionPerPlay
        ) {
            return TotalStaminaToPlay(
                       star, 
                       playerLevel, 
                       autoRecoverStamina, 
                       staminaPerPlay
                    ) * collectionPerPlay;
        }
    }
}
