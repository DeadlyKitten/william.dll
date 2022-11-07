using HarmonyLib;
using TMPro;
using System.Collections;

namespace william.gay
{
    [HarmonyPatch(typeof(TextMeshPro))]
    [HarmonyPatch("Awake")]
    internal class TextMeshPro_Awake
    {
        private static void Postfix(TextMeshPro __instance)
        {
            return;

            __instance.overrideColorTags = true;
            if (Plugin.fontAsset)
                __instance.font = Plugin.fontAsset.font;
            __instance.UpdateFontAsset();
            if (!Plugin.offsets.TryGetValue(__instance.GetHashCode(), out var value)) Plugin.offsets.Add(__instance.GetHashCode(), (float)UnityEngine.Random.Range(0, 100) / 100);

            __instance.SetText(new Zalgo.ZalgoString(__instance.text, Zalgo.FuckUpMode.Max, Zalgo.FuckUpPosition.All).ToString());
        }
    }
}