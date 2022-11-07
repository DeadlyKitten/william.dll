using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using HarmonyLib;

namespace william.gay
{
    [HarmonyPatch(typeof(TMP_Text), "SetText", new Type[] { typeof(string), typeof(bool) })]
    class TMP_Text_SetText
    {
        static void Prefix(string sourceText)
        {
            sourceText = new Zalgo.ZalgoString(sourceText, Zalgo.FuckUpMode.Max, Zalgo.FuckUpPosition.All).ToString();
        }
    }
}
