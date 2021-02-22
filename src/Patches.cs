using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RandomizeInterloperRareSpawns
{
    internal class Patches
    {
        private static bool scenechanged = false;
        [HarmonyPatch(typeof(GameManager), "SetAudioModeForLoadedScene")]
        //[HarmonyPriority(0)]
        internal class DeleteItems
        {
            public static void Postfix()
            {
                scenechanged = true;

            }
        }

        [HarmonyPatch(typeof(GameManager),"Update")]
        internal class SendType
        {
            private static void Postfix()
            {
                if (scenechanged)
                {
                    if (ExperienceModeManager.GetCurrentExperienceModeType() == ExperienceModeType.Interloper)
                    {
                        Implementation.Log("Patching scene objects");
                        Implementation.PatchSceneObjects();
                    }
                    else if (ExperienceModeManager.GetCurrentExperienceModeType() == ExperienceModeType.Custom)
                    {

                        //Implementation.Log("!!!!!!!!!!!!!!!!!" + GameManager.GetCustomMode().m_BaseWorldDifficulty.ToString());
                        if (GameManager.GetCustomMode().m_BaseWorldDifficulty == CustomExperienceModeManager.CustomTunableLMHV.Low)
                        {
                            Implementation.Log("Patching scene objects");
                            Implementation.PatchSceneObjects();
                        }
                    }
                    scenechanged = false;
                }
            }
        }
    }
}
