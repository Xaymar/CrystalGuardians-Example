#if !UNITY_EDITOR && !UNITY_STANDALONE
using BepInEx;
using UnityEngine;

namespace Xaymar.Example
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            
            // Start of: AssetBundle loader.
            string whoAmI = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string whereAmI = System.IO.Path.GetDirectoryName(whoAmI);
            if (string.IsNullOrEmpty(whereAmI)) {
                throw new System.IO.FileNotFoundException("Failed to find myself.");
            }

            // - Load all Asset Bundles in our directory.
            foreach (var file in System.IO.Directory.EnumerateFiles(whereAmI, "*.assetbundle"))
            {
                // Can be optimized to load asynchronously, which speeds up loading with many asset bundles.
                Logger.LogInfo($"Loading bundle '{file}'...");
                var bundle = AssetBundle.LoadFromFile(file);
            }
            // End of: AssetBundle loader.

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}

#endif