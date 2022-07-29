extern alias Hinterland;
using Hinterland;
using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;

namespace RandomizeInterloperRareSpawns
{
	internal static class Patches
	{
		private static HashSet<string> rareLootNames = new() 
		{ 
			"GEAR_Hacksaw", 
			"GEAR_Hammer", 
			"GEAR_KeroseneLampB", 
			"GEAR_MagnifyingLens", 
			"GEAR_Firestriker", 
			"GEAR_BedRoll" 
		};
		
		private static bool scenechanged = false;
		
		[HarmonyPatch(typeof(GameManager), nameof(GameManager.SetAudioModeForLoadedScene))]
		private static class DeleteItems
		{
			public static void Postfix()
			{
				scenechanged = true;
			}
		}

		[HarmonyPatch(typeof(GameManager), "Update")]
		private static class SendType
		{
			private static void Postfix()
			{
				if (scenechanged)
				{
					if (ExperienceModeManager.GetCurrentExperienceModeType() == ExperienceModeType.Interloper)
					{
						Implementation.Log("Patching scene objects");
						PatchSceneObjects();
					}
					else if (ExperienceModeManager.GetCurrentExperienceModeType() == ExperienceModeType.Custom 
						&& GameManager.GetCustomMode().m_BaseWorldDifficulty == CustomExperienceModeManager.CustomTunableLMHV.Low)
					{
						Implementation.Log("Patching scene objects");
						PatchSceneObjects();
					}
					scenechanged = false;
				}
			}
		}

		private static void PatchSceneObjects()
		{
			//Get list of all root objects
			List<GameObject> rObjs = SpawnUtils.GetRootObjects();

			foreach (GameObject rootObj in rObjs)
			{
				if (rootObj.GetComponent<MissionObjectIdentifier>() != null && IsRareLoot(rootObj))
				{
					//Log("Root Object '{0}' Destroyed",rootObj.name);
					Object.Destroy(rootObj);
					continue;
				}

				List<GameObject> children = new List<GameObject>();

				SpawnUtils.GetChildren(rootObj, children);

				PatchObjects(children);
			}
		}

		private static void PatchObjects(List<GameObject> objs)
		{
			foreach (GameObject obj in objs)
			{
				MissionObjectIdentifier objectIdentifier = obj.GetComponent<MissionObjectIdentifier>();
				if (objectIdentifier != null && IsRareLoot(obj))
				{
					//Log("{0} destroyed at {1}",obj.name,obj.transform.position.ToString());
					Object.Destroy(obj);
				}
			}
		}

		private static bool IsRareLoot(GameObject gameObject)
		{
			return rareLootNames.Contains(gameObject.name);
		}
	}
}
