namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/5
// ReSharper disable once UnusedType.Global
public sealed class Day05 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
                                     seeds: 79 14 55 13

                                     seed-to-soil map:
                                     50 98 2
                                     52 50 48

                                     soil-to-fertilizer map:
                                     0 15 37
                                     37 52 2
                                     39 0 15

                                     fertilizer-to-water map:
                                     49 53 8
                                     0 11 42
                                     42 0 7
                                     57 7 4

                                     water-to-light map:
                                     88 18 7
                                     18 25 70

                                     light-to-temperature map:
                                     45 77 23
                                     81 45 19
                                     68 64 13

                                     temperature-to-humidity map:
                                     0 69 1
                                     1 0 69

                                     humidity-to-location map:
                                     60 56 37
                                     56 93 4
                                     """;

    public Day05() =>
        input = File.ReadAllText(InputFilePath);

    private static RangeMapGroup ProcessInput(string input)
    {
        var localInput = input.Replace("\n\r", "\n").Trim();
        var groups = localInput.Split("\n\n").Select(g => g.Trim()).ToList() ?? [];

        var seedsString = groups[0].Replace("seeds: ", string.Empty, StringComparison.OrdinalIgnoreCase).Trim();

        var seedStrings = seedsString.Split(" ");
        List<long> seeds = [];

        foreach (var seedString in seedStrings)
        {
            if (!long.TryParse(seedString, out var seed))
            {
                continue;
            }
            seeds.Add(seed);
        }

        return new RangeMapGroup
        {
            Seeds = seeds,
            SeedsToSoil = GetRangeMaps(CleanGroup(groups[1])),
            SoilToFertilizer = GetRangeMaps(CleanGroup(groups[2])),
            FertilizerToWater = GetRangeMaps(CleanGroup(groups[3])),
            WaterToLight = GetRangeMaps(CleanGroup(groups[4])),
            LightToTemperature = GetRangeMaps(CleanGroup(groups[5])),
            TemperatureToHumidity = GetRangeMaps(CleanGroup(groups[6])),
            HumidityToLocation = GetRangeMaps(CleanGroup(groups[7])),
        };

        static List<string> CleanGroup(string group) => group
            .Split('\n')
            .Skip(1)
            .Select(g => g.Trim())
            .ToList();

        static List<RangeMap> GetRangeMaps(List<string> rangeMapLines)
        {
            List<RangeMap> rangeMaps = [];

            foreach (var rangeMapLine in rangeMapLines)
            {
                var numStrings = rangeMapLine.Split(" ").Select(l => l.Trim()).ToList();
                if (numStrings.Count != 3)
                {
                    throw new Exception("Invalid range definition");
                }

                var destinationRangeStartString = numStrings[0];
                if (!long.TryParse(destinationRangeStartString, out var destinationRangeStart))
                {
                    throw new Exception("Can't parse number");
                }

                var sourceRangeStartString = numStrings[1];
                if (!long.TryParse(sourceRangeStartString, out var sourceRangeStart))
                {
                    throw new Exception("Can't parse number");
                }

                var rangeLengthString = numStrings[2];
                if (!long.TryParse(rangeLengthString, out var rangeLength))
                {
                    throw new Exception("Can't parse number");
                }

                rangeMaps.Add(new RangeMap(destinationRangeStart, sourceRangeStart, rangeLength));
            }

            return rangeMaps;
        }
    }

    public override ValueTask<string> Solve_1()
    {
        var rangeMapGroup = ProcessInput(input);
        List<long> locations = [];

        foreach (var seed in rangeMapGroup.Seeds)
        {
            var seedLocation = GetLocationFromSeed(rangeMapGroup, seed);
            locations.Add(seedLocation);
        }

        return new(locations.Min().ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var rangeMapGroup = ProcessInput(TestInput);

        return new();
    }

    private static long GetLocationFromSeed(RangeMapGroup rangeMapGroup, long seedNum)
    {
        var seed = rangeMapGroup.Seeds.FirstOrDefault(s => s == seedNum);
        if (seed == 0)
        {
            throw new Exception("Invalid seed");
        }

        var soil = GetMappedThing(rangeMapGroup.SeedsToSoil, seed);
        var fertilizer = GetMappedThing(rangeMapGroup.SoilToFertilizer, soil);
        var water = GetMappedThing(rangeMapGroup.FertilizerToWater, fertilizer);
        var light = GetMappedThing(rangeMapGroup.WaterToLight, water);
        var temperature = GetMappedThing(rangeMapGroup.LightToTemperature, light);
        var humidity = GetMappedThing(rangeMapGroup.TemperatureToHumidity, temperature);
        var location = GetMappedThing(rangeMapGroup.HumidityToLocation, humidity);

        return location;
    }

    private static long GetMappedThing(List<RangeMap> destinationRange, long sourceId)
    {
        foreach (var rangeMap in destinationRange)
        {
            for (var i = 0; i < rangeMap.RangeLength; i++)
            {
                if (rangeMap.SourceRangeStart + i == sourceId)
                {
                    return rangeMap.DestinationRangeStart + i;
                }
            }
        }

        return sourceId;
    }

    private class RangeMap(long destinationRangeStart, long sourceRangeStart, long rangeLength)
    {
        public long DestinationRangeStart { get; } = destinationRangeStart;

        public long SourceRangeStart { get; } = sourceRangeStart;

        public long RangeLength { get; } = rangeLength;
    }

    private class RangeMapGroup()
    {
        public List<long> Seeds { get; set; } = [];

        public List<RangeMap> SeedsToSoil { get; set; } = [];

        public List<RangeMap> SoilToFertilizer { get; set; } = [];

        public List<RangeMap> FertilizerToWater { get; set; } = [];

        public List<RangeMap> WaterToLight { get; set; } = [];

        public List<RangeMap> LightToTemperature { get; set; } = [];

        public List<RangeMap> TemperatureToHumidity { get; set; } = [];

        public List<RangeMap> HumidityToLocation { get; set; } = [];
    }
}
