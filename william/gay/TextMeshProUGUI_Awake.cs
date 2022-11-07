using HarmonyLib;
using TMPro;
using System.Collections;
using william.utilities;

namespace william.gay
{
    [HarmonyPatch(typeof(TextMeshProUGUI))]
    [HarmonyPatch("Awake")]
    internal class TextMeshProUGUI_Awake
    {
        private static void Postfix(TextMeshPro __instance)
        {
            Plugin.offsets.Add(__instance.GetHashCode(), (float)UnityEngine.Random.Range(0, 100) / 100);
            __instance.overrideColorTags = true;
            //if (Plugin.fontAsset)
            //{
            //    __instance.font = Plugin.fontAsset.font;
            //    __instance.fontSize = __instance.fontSize * 0.8f;
            //}
            //__instance.UpdateFontAsset();

            SharedCoroutineStarter.StartCoroutine(ChangeTextOnNextFrame(__instance));
        }

        static IEnumerator ChangeTextOnNextFrame(TextMeshPro __instance)
        {
            yield return null;

            __instance.text = new Zalgo.ZalgoString(__instance.text, Zalgo.FuckUpMode.Max, Zalgo.FuckUpPosition.All).ToString();
        }
    }
}
