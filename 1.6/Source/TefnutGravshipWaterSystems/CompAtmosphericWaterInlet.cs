using System.Collections.Generic;
using System.Text;
using DubsBadHygiene;
using RimWorld;
using Verse;

namespace TefnutGravshipWaterSystems
{
    [StaticConstructorOnStartup]
    public class CompAtmosphericWaterInlet : ThingComp
    {
        public CompPipe PipeComp;
        public float AtmosphericCapacity;

        public CompProperties_AtmosphericWaterInlet Props => (CompProperties_AtmosphericWaterInlet)props;

        public override void PostSpawnSetup(bool respawningAfterLoad)
        {
            base.PostSpawnSetup(respawningAfterLoad);
            PipeComp = parent.GetComp<CompPipe>();
            if (PipeComp != null)
            {
                PipeComp.MapComp.RegisterUser(new List<IntVec3> { parent.Position });
                UpdateCap();
            }
        }

        public override void PostDeSpawn(Map map, DestroyMode mode = DestroyMode.Vanish)
        {
            base.PostDeSpawn(map, mode);
            if (map != null)
            {
                map.Hygiene()?.DeregisterUser(new List<IntVec3> { parent.Position });
            }
        }

        public override void CompTick()
        {
            base.CompTick();
            if (PipeComp?.pipeNet == null) return;
            float waterPerTick = Props.AtmosphericRate / 60000f;
            PipeComp.pipeNet.PushWater(waterPerTick);
        }

        private void UpdateCap()
        {
            AtmosphericCapacity = Props.AtmosphericRate * ModOption.WaterPumpCapacity.Val;
        }

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            yield return DubUtils.Command_Wikilink();
        }

        public override string CompInspectStringExtra()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{"AtmosphericYield".Translate()}: {AtmosphericCapacity.ToString("0")} L/day");
            if (PipeComp?.pipeNet != null)
            {
                sb.AppendLine($"{"TotalWaterStorage".Translate()}: {PipeComp.pipeNet.WaterStorage.ToString("0.0")}");
                //sb.AppendLine($"{"NetworkCapacity".Translate()}: {GenText.ToStringPercent(PipeComp.pipeNet.WaterCap, "0.0")}");
            }
            return GenText.TrimEndNewlines(sb.ToString());
        }
    }
}
