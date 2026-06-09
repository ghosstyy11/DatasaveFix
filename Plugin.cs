using System;
using BepInEx;
using UnityEngine;
using Utilla;
using HarmonyLib;
using System.Reflection;

namespace DatasaveFix
{
    [BepInPlugin("com.ghosty.datasavefix", "DatasaveFix", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        void OnEnable()
        {
            ApplyHarmonyPatches();
        }

        private static Harmony instance;

        public static bool IsPatched { get; private set; }
        public const string InstanceId = "com.ghosty.datasavefix";

        internal static void ApplyHarmonyPatches()
        {
            if (!IsPatched)
            {
                if (instance == null)
                {
                    instance = new Harmony(InstanceId);
                }

                instance.PatchAll(Assembly.GetExecutingAssembly());
                IsPatched = true;
            }
        }
    }
}
