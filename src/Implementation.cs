using MelonLoader;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RandomizeInterloperRareSpawns
{
    internal class Implementation : MelonMod
    {
        public static string[] rareLootNames = { "GEAR_Hacksaw", "GEAR_Hammer", "GEAR_KeroseneLampB", "GEAR_MagnifyingLens", "GEAR_Firestriker", "GEAR_BedRoll" };

        public override void OnApplicationStart()
        {
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
            Settings.OnLoad();
            ProbabilityFunctions.AddToModComponent();
        }

        internal static void Log(string message)
        {
            MelonLogger.Msg(message);
        }

        internal static void Log(string message, params object[] parameters)
        {
            string preformattedMessage = string.Format(message, parameters);
            Log(preformattedMessage);
        }

        internal static void PatchSceneObjects()
        {
            //Get list of all root objects
            List<GameObject> rObjs = SpawnUtils.GetRootObjects();

            foreach (GameObject rootObj in rObjs)
            {
                if (rootObj.GetComponent<MissionObjectIdentifier>() != null && IsRareLoot(rootObj))
                {
                    //Log("Root Object '{0}' Destroyed",rootObj.name);
                    UnityEngine.Object.Destroy(rootObj);
                    continue;
                }

                List<GameObject> children = new List<GameObject>();

                SpawnUtils.GetChildren(rootObj, children);

                PatchObjects(children);
            }
        }

        internal static void PatchObjects(List<GameObject> objs)
        {
            foreach (GameObject obj in objs)
            {
                MissionObjectIdentifier objectIdentifier = obj.GetComponent<MissionObjectIdentifier>();
                if (objectIdentifier != null && IsRareLoot(obj))
                {
                    //Log("{0} destroyed at {1}",obj.name,obj.transform.position.ToString());
                    UnityEngine.Object.Destroy(obj);
                }
            }
        }

        public static bool IsRareLoot(GameObject gameObject)
        {
            return rareLootNames.Contains<string>(gameObject.name);
        }
    }
}
