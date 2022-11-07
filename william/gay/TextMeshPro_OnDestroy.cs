using HarmonyLib;
using TMPro;

namespace william.gay
{
    [HarmonyPatch(typeof(TextMeshPro))]
    [HarmonyPatch("OnDestroy")]
    internal class TextMeshPro_OnDestroy
    {
        private static void Postfix(TextMeshPro __instance) => Plugin.offsets.Remove(__instance.GetHashCode());
    }
}