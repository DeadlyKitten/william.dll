using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Linq;
using BepInEx;

namespace william
{
    [BepInPlugin("com.steven.nasb.william.gay", "william.dll", "2.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        internal static Plugin Instance;

        public static Dictionary<int, float> offsets;
        public static Shader shader;

        public static TextMeshPro fontAsset;

        public void Awake()
        {
            if (Instance)
            {
                DestroyImmediate(this);
                return;
            }
            Instance = this;

            offsets = new Dictionary<int, float>();
            UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
        }

        public void Start()
        {
            GetFont();

            Logger.LogDebug("Applying Harmony Patches");
            try
            {
                var harmony = new Harmony("com.steven.beatsaber.william.gay");
                harmony.PatchAll(Assembly.GetExecutingAssembly());

                Logger.LogInfo("william gay");
            }
            catch (Exception e)
            {
                Logger.LogError($"{e.Message}\n{e.StackTrace}");
            }
        }

        public void GetFont()
        {
            var bundle = AssetBundle.LoadFromStream(Assembly.GetCallingAssembly().GetManifestResourceStream("william.resources.comicsans"));
            var prefab = bundle.LoadAsset<GameObject>("Assets/Text.prefab");
            fontAsset = prefab?.GetComponent<TextMeshPro>();
        }

        public void OnApplicationQuit() { }

        public void OnFixedUpdate() { }

        public void OnUpdate() { }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene) { }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode) { }

        public void OnSceneUnloaded(Scene scene) { }
    }
}
