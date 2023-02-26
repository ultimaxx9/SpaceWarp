using HarmonyLib;
using KSP.Game;
using KSP.Logging;
using SpaceWarp.UI;
using System.Reflection;
using UnityEngine.SceneManagement;
namespace SpaceWarp
{
    public class Entrypoint
    {
        private static bool _patched;
     
        private const string HARMONY_PACKAGE_URL = "com.github.x606.spacewarp";

        /// <summary>
        /// Add OnGameStarted as postfix to StartGame
        /// </summary>
        static void OnSceneLoaded(Scene unused1, LoadSceneMode unused2)
        {
            if (!_patched)
            {
                InitializePatches();
                _patched = true;
            }
        }

        /// <summary>
        /// Initializes Harmony
        /// </summary>

        static void InitializePatches()
        {
            Harmony harmony = new Harmony(HARMONY_PACKAGE_URL);

            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}