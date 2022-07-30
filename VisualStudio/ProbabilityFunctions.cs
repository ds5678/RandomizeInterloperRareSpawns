using GearSpawner;

namespace RandomizeInterloperRareSpawns;

internal static class ProbabilityFunctions
{
	private const int TotalBedrolls = 55;
	private const int TotalHacksaws = 55;
	private const int TotalHammers = 45;
	private const int TotalLanterns = 33;
	private const int TotalMagLens = 33;
	private const int TotalFirestrikers = 22;

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
			"gear_bedroll" => 100f / TotalBedrolls * RareSpawnSettings.Instance.bedrollSpawnExpectation,
			"gear_firestriker" => 100f / TotalFirestrikers * RareSpawnSettings.Instance.firestrikerSpawnExpectation,
			"gear_hacksaw" => 100f / TotalHacksaws * RareSpawnSettings.Instance.hacksawSpawnExpectation,
			"gear_hammer" => 100f / TotalHammers * RareSpawnSettings.Instance.hammerSpawnExpectation,
			"gear_kerosenelampb" => 100f / TotalLanterns * RareSpawnSettings.Instance.lanternSpawnExpectation,
			"gear_magnifyinglens" => 100f / TotalMagLens * RareSpawnSettings.Instance.maglensSpawnExpectation,
			_ => 0f,
		};
	}
}
