using System;
using System.Collections.Generic;
using System.Text;

namespace CgssEventTool.BusinessLogicLayer
{
    public class CgssCollect
    {
        public static readonly int MaxPlayerLevel = 500;
        public static readonly int MaxStarCapacity = 75000;

        public static int PlayerLevelToStarUsage(int playerLevel)
        {
            if (playerLevel <= 0) return -1; // 防呆

            if (playerLevel < 4) return 12;
            if (playerLevel < 12) return 11;
            if (playerLevel < 23) return 10;
            if (playerLevel < 38) return 9;
            if (playerLevel < 59) return 8;
            if (playerLevel < 86) return 7;
            if (playerLevel < 130) return 6;
            if (playerLevel < 198) return 5;
            if (playerLevel < 315) return 4;

            return 3;
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
