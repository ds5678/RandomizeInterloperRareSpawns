extern alias Hinterland;
using Hinterland;
using MelonLoader;
using ModSettings;

namespace RandomizeInterloperRareSpawns;

internal sealed class Implementation : MelonMod
{
	public static Implementation? Instance { get; private set; }

	public Implementation()
	{
		Instance = this;
	}
	
	public override void OnApplicationStart()
	{
		RareSpawnSettings.Instance.AddToModSettings("Randomize Interloper Rare Spawns", MenuType.MainMenuOnly);
		ProbabilityFunctions.AddToModComponent();
	}

	internal static void Log(string message)
	{
		if (Instance is not null)
		{
			Instance.LoggerInstance.Msg(message);
		}
		else
		{
			MelonLogger.Msg(message);
		}
	}
}
