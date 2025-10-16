using DubsBadHygiene;

namespace TefnutGravshipWaterSystems
{
    public class CompProperties_AtmosphericWaterStation : CompProperties_WaterPumpingStation
    {
        public CompProperties_AtmosphericWaterStation() => this.compClass = typeof (CompAtmosphericWaterStation);
    }
}