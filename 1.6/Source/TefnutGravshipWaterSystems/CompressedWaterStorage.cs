using DubsBadHygiene;

namespace TefnutGravshipWaterSystems
{
    public class CompProperties_CompressedWaterStorage : CompProperties_WaterStorage
    {
        public float UnpoweredWaterStorageCap = 0F;

        public CompProperties_CompressedWaterStorage() => this.compClass = typeof (CompCompressedWaterStorage);
    }
}