using ModSettings;

namespace RandomizeInterloperRareSpawns
{
    internal class RareSpawnSettings : JsonModSettings
	{
		internal static RareSpawnSettings Instance { get; } = new();
		
		[Section("Random Spawns")]
        [Name("Heavy Hammer Spawn Expectation")]
        [Description("The expected number of times this item will randomly spawn in the world based on statistics. Recommended is 4")]
        [Slider(0f, 20, 201)]
        public float hammerSpawnExpectation = 4f;

        [Name("Hacksaw Spawn Expectation")]
        [Description("The expected number of times this item will randomly spawn in the world based on statistics. Recommended is 5")]
        [Slider(0f, 20, 201)]
        public float hacksawSpawnExpectation = 5f;

        [Name("Magnifying Lens Spawn Expectation")]
        [Description("The expected number of times this item will randomly spawn in the world based on statistics. Recommended is 2")]
        [Slider(0f, 20, 201)]
        public float maglensSpawnExpectation = 2f;

        [Name("Firestriker Spawn Expectation")]
        [Description("The expected number of times this item will randomly spawn in the world based on statistics. Recommended is 2")]
        [Slider(0f, 20, 201)]
        public float firestrikerSpawnExpectation = 2f;

        [Name("Storm Lantern Spawn Expectation")]
        [Description("The expected number of times this item will randomly spawn in the world based on statistics. Recommended is 3")]
        [Slider(0f, 20, 201)]
        public float lanternSpawnExpectation = 3f;

        [Name("Bedroll Spawn Expectation")]
        [Description("The expected number of times this item will randomly spawn in the world based on statistics. Recommended is 5")]
        [Slider(0f, 20, 201)]
        public float bedrollSpawnExpectation = 5f;


        [Section("Guaranteed Spawns")]
        [Name("Guaranteed Heavy Hammer Spawn")]
        [Description("If yes, there is a guaranteed spawn for the heavy hammer inside the cave by the Monolith Lake in Hushed River Valley. If no, it is possible (but unlikely) that the heavy hammer might not spawn anywhere in the world.")]
        public bool guaranteedHammer = true;

        [Name("Guaranteed Hacksaw Spawn")]
        [Description("If yes, there is a guaranteed spawn for the hacksaw inside the Cannery Workshop in Bleak Inlet. If no, it is possible (but unlikely) that the hacksaw might not spawn anywhere in the world.")]
        public bool guaranteedHacksaw = true;

        [Name("Guaranteed Magnifying Lens Spawn")]
        [Description("If yes, there is a guaranteed spawn for the magnifying lens in the tail section at the summit of Timberwolf Mountion. If no, it is possible (but unlikely) that the magnifying lens might not spawn anywhere in the world.")]
        public bool guaranteedMagLens = true;

        [Name("Guaranteed Firestriker Spawn")]
        [Description("If yes, there is a guaranteed spawn for the firestriker in the Broken Railroad Ravine near the supply container. If no, it is possible (but unlikely) that the firestriker might not spawn anywhere in the world.")]
        public bool guaranteedFirestriker = true;

        [Name("Guaranteed Bedroll Spawn")]
        [Description("If yes, there is a guaranteed spawn for the bedroll at the Homesteader's Respite in Ash Canyon. If no, it is possible (but unlikely) that the bedroll might not spawn anywhere in the world.")]
        public bool guaranteedBedroll = true;

        [Name("Guaranteed Storm Lantern Spawn")]
        [Description("If yes, there is a guaranteed spawn for the Storm Lantern in the middle layer of the Cinder Hills Coal Mine. If no, it is possible (but unlikely) that the storm lantern might not spawn anywhere in the world.")]
        public bool guaranteedLantern = true;
    }
}
