using Verse;

namespace TefnutGravshipWaterSystems
{
    public class CompProperties_AtmosphericWaterInlet : CompProperties
    {
        public GraphicData effects;
        public float AtmosphericRate = 1500f;
        public bool Piped = true;
        public CompProperties_AtmosphericWaterInlet()
        {
            compClass = typeof(CompAtmosphericWaterInlet);
        }
    }
}