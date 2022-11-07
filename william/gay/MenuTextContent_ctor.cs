using Nick;
using HarmonyLib;
using TMPro;
using UnityEngine;
using System.Collections;
using william.utilities;
using System;

namespace william.gay
{
    [HarmonyPatch(typeof(MenuTextContent), MethodType.Constructor)]
    internal class MenuTextContent_ctor
    {
        private static void Postfix(ref MenuTextContent __instance)
        {
            return;
            SharedCoroutineStarter.StartCoroutine(DestroyExtraTexts(__instance));
        }

        static IEnumerator DestroyExtraTexts(MenuTextContent instance)
        {
            yield return new WaitForSeconds(0.1f);

            if (instance.textsList == null) yield break;

            try
            {
                for (int i = 0; i < instance.textsList.Length; i++)
                {
                    if (instance.textsList[i].gameObject.name != "Text")
                        instance.textsList[i].gameObject.SetActive(false);
                }
            }
            catch (Exception) { }
        }
    }
}