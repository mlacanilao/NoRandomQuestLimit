using BepInEx;
using HarmonyLib;

namespace NoRandomQuestLimit
{
    internal static class ModInfo
    {
        internal const string Guid = "omegaplatinum.elin.norandomquestlimit";
        internal const string Name = "No Random Quest Limit";
        internal const string Version = "1.0.0.0";
    }
    
    [BepInPlugin(GUID: ModInfo.Guid, Name: ModInfo.Name, Version: ModInfo.Version)]
    internal class NoRandomQuestLimit : BaseUnityPlugin
    {
        private void Awake()
        {
            var harmony = new Harmony(id: ModInfo.Guid);
            harmony.PatchAll();
        }
    }
    
    [HarmonyPatch(declaringType: typeof(QuestManager), methodName: nameof(QuestManager.CountRandomQuest))]
    internal static class PatchCountRandomQuest
    {
        public static bool Prefix(ref int __result)
        {
            __result = 0;
            return false;
        }
    }
}