using HarmonyLib;
using System;
using TMPro;
using UnityEngine;
using william.utilities;

namespace william.gay
{
    [HarmonyPatch(typeof(TextMeshProUGUI))]
    [HarmonyPatch("InternalUpdate")]
    internal class TextMeshProUGUI_Update
    {
        private static void Postfix(TextMeshPro __instance)
        {

            return;

            if (!Plugin.offsets.TryGetValue(__instance.GetHashCode(), out var offset))
                Plugin.offsets.Add(__instance.GetHashCode(), (float)UnityEngine.Random.Range(0, 100) / 100);

            var textInfo = __instance.textInfo;
            var currentCharacter = 0;
            var hue = Mathf.PingPong(Time.time * 0.05f + offset, 1);
            var characterCount = textInfo.characterCount;

            Color32[] newVertexColors;
            Color32 c0 = __instance.color;

            if (characterCount == 0) return;

            if (characterCount > 300)
            {
                __instance.color = HSBColor.ToColor(new HSBColor(hue, 0.6f, 1));
                return;
            }

            try
            {
                for (var i = 0; i < characterCount; i++)
                {
                    var materialIndex = textInfo.characterInfo[currentCharacter].materialReferenceIndex;
                    newVertexColors = textInfo.meshInfo[materialIndex].colors32;
                    var vertexIndex = textInfo.characterInfo[currentCharacter].vertexIndex;

                    if (textInfo.characterInfo[currentCharacter].isVisible)
                    {
                        c0 = HSBColor.ToColor(new HSBColor(hue, 0.6f, 1));

                        try
                        {
                            newVertexColors[vertexIndex + 0] = c0;
                            newVertexColors[vertexIndex + 1] = c0;
                            newVertexColors[vertexIndex + 2] = c0;
                            newVertexColors[vertexIndex + 3] = c0;
                        }
                        catch (Exception e) { }

                        __instance.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
                    }

                    currentCharacter = (currentCharacter + 1);
                    hue += 0.05f;
                    hue = Mathf.Repeat(hue, 1);
                }
            }
            catch (Exception e) { }
        }
    }
}