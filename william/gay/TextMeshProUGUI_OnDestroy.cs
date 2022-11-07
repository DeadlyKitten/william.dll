using HarmonyLib;
using TMPro;

namespace william.gay
{
    [HarmonyPatch(typeof(TextMeshProUGUI))]
    [HarmonyPatch("OnDestroy")]
    internal class TextMeshProUGUI_OnDestroy
    {
        private static void Postfix(TextMeshPro __instance) => Plugin.offsets.Remove(__instance.GetHashCode());
    }
}
