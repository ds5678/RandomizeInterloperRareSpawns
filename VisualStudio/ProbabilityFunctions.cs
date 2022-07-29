using GearSpawner;
using System;

namespace RandomizeInterloperRareSpawns
{
    internal static class ProbabilityFunctions
    {
        internal static void AddToModComponent()
        {
            SpawnTagManager.AddToTaggedFunctions("RandomizeInterloperRareSpawns_Guaranteed", new Func<DifficultyLevel, FirearmAvailability, GearSpawnInfo, float>(GuaranteedSpawns));
            SpawnTagManager.AddToTaggedFunctions("RandomizeInterloperRareSpawns_Random", new Func<DifficultyLevel, FirearmAvailability, GearSpawnInfo, float>(RandomSpawns));
        }
        public static float GuaranteedSpawns(DifficultyLevel difficultyLevel,FirearmAvailability firearmAvailability,GearSpawnInfo gearSpawnInfo)
        {
            if (difficultyLevel != DifficultyLevel.Interloper) return 0f;
            switch (gearSpawnInfo.PrefabName)
            {
                case "gear_bedroll":
                    if (Settings.options.guaranteedBedroll) return 100f;
                    else return 0f;
                case "gear_firestriker":
                    if (Settings.options.guaranteedFirestriker) return 100f;
                    else return 0f;
                case "gear_hacksaw":
                    if (Settings.options.guaranteedHacksaw) return 100f;
                    else return 0f;
                case "gear_hammer":
                    if (Settings.options.guaranteedHammer) return 100f;
                    else return 0f;
                case "gear_kerosenelampb":
                    if (Settings.options.guaranteedLantern) return 100f;
                    else return 0f;
                case "gear_magnifyinglens":
                    if (Settings.options.guaranteedMagLens) return 100f;
                    else return 0f;
                default:
                    return 0f;
            }
        }
        public static float RandomSpawns(DifficultyLevel difficultyLevel, FirearmAvailability firearmAvailability, GearSpawnInfo gearSpawnInfo)
        {
            switch (difficultyLevel)
            {
                case DifficultyLevel.Interloper:
                    return GetRareItemSpawnProbability(gearSpawnInfo.PrefabName);
                default:
                    return 0f;
            }
        }
        private static float GetRareItemSpawnProbability(string itemName)
        {
            switch (itemName.ToLower())
            {
                case "gear_bedroll":
                    return 100f * Settings.options.bedrollSpawnExpectation / 50f;
                case "gear_firestriker":
                    return 100f * Settings.options.firestrikerSpawnExpectation / 20f;
                case "gear_hacksaw":
                    return 100f * Settings.options.hacksawSpawnExpectation / 50f;
                case "gear_hammer":
                    return 100f * Settings.options.hammerSpawnExpectation / 40f;
                case "gear_kerosenelampb":
                    return 100f * Settings.options.lanternSpawnExpectation / 30f;
                case "gear_magnifyinglens":
                    return 100f * Settings.options.maglensSpawnExpectation / 20f;
                default:
                    return 0f;
            }
        }
    }
}
