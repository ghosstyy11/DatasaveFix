using System;
using System.IO;
using HarmonyLib;
using UnityEngine;
using Modio.FileIO;

namespace DatasaveFix.Patches
{
    [HarmonyPatch(typeof(BaseDataStorage), "Init")]
    class PatchModDirectory
    {
        static void Postfix()
        {
            try
            {
                string newDir = Path.Combine(Application.persistentDataPath, "luauDataSaves");

                typeof(Bindings.JSON).GetField("ModIODirectory",
                    System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Static).SetValue(null, newDir);
            }
            catch (Exception e)
            {
                Debug.Log("Failed to redirect ModIODirectory: " + e);
            }
        }
    }
}
