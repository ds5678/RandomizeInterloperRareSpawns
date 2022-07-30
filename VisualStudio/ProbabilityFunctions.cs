using GearSpawner;

namespace RandomizeInterloperRareSpawns;

internal static class ProbabilityFunctions
{
	internal static void AddToModComponent()
	{
		SpawnTagManager.AddFunction("RandomizeInterloperRareSpawns_Guaranteed", GuaranteedSpawns);
		SpawnTagManager.AddFunction("RandomizeInterloperRareSpawns_Random", RandomSpawns);
	}
	
	public static float GuaranteedSpawns(DifficultyLevel difficultyLevel,FirearmAvailability firearmAvailability,GearSpawnInfo gearSpawnInfo)
	{
		if (difficultyLevel != DifficultyLevel.Interloper)
		{
			return 0f;
		}

		return gearSpawnInfo.PrefabName switch
		{
			"gear_bedroll" => RareSpawnSettings.Instance.guaranteedBedroll ? 100f : 0f,
			"gear_firestriker" => RareSpawnSettings.Instance.guaranteedFirestriker ? 100f : 0f,
			"gear_hacksaw" => RareSpawnSettings.Instance.guaranteedHacksaw ? 100f : 0f,
			"gear_hammer" => RareSpawnSettings.Instance.guaranteedHammer ? 100f : 0f,
			"gear_kerosenelampb" => RareSpawnSettings.Instance.guaranteedLantern ? 100f : 0f,
			"gear_magnifyinglens" => RareSpawnSettings.Instance.guaranteedMagLens ? 100f : 0f,
			_ => 0f,
		};
	}
	
	public static float RandomSpawns(DifficultyLevel difficultyLevel, FirearmAvailability firearmAvailability, GearSpawnInfo gearSpawnInfo)
	{
		return difficultyLevel switch
		{
			DifficultyLevel.Interloper => GetRareItemSpawnProbability(gearSpawnInfo.PrefabName),
			_ => 0f,
		};
	}
	
	private static float GetRareItemSpawnProbability(string itemName)
	{
		return itemName.ToLowerInvariant() switch
		{
			"gear_bedroll" => 100f * RareSpawnSettings.Instance.bedrollSpawnExpectation / 50f,
			"gear_firestriker" => 100f * RareSpawnSettings.Instance.firestrikerSpawnExpectation / 20f,
			"gear_hacksaw" => 100f * RareSpawnSettings.Instance.hacksawSpawnExpectation / 50f,
			"gear_hammer" => 100f * RareSpawnSettings.Instance.hammerSpawnExpectation / 40f,
			"gear_kerosenelampb" => 100f * RareSpawnSettings.Instance.lanternSpawnExpectation / 30f,
			"gear_magnifyinglens" => 100f * RareSpawnSettings.Instance.maglensSpawnExpectation / 20f,
			_ => 0f,
		};
	}
}
