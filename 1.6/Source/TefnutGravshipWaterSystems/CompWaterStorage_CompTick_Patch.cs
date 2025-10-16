using System.Linq;
using DubsBadHygiene;
using HarmonyLib;
using Verse;

namespace TefnutGravshipWaterSystems
{
    [StaticConstructorOnStartup]
    public static class TefnutGravshipWaterSystemsMod
    {
        static TefnutGravshipWaterSystemsMod()
        {
            new Harmony("TefnutGravshipWaterSystems").PatchAll();
        }
    }
    
    [HarmonyPatch(typeof(CompWaterStorage))]
    [HarmonyPatch(nameof(CompWaterStorage.CompTick))]
    static class CompWaterStorage_CompTick_Patch
    {
        static void Postfix(CompWaterStorage __instance)
        {
            if (__instance.WaterQuality == ContaminationLevel.Untreated && __instance.PipeComp.pipeNet.WaterWells.All(w => w is ExternalWaterInlet))
            {
                __instance.WaterQuality = ContaminationLevel.Treated;
            }

            Harmony.DEBUG = true;
        }
    }
}