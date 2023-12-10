namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/5
public class Day05 : BaseLibraryDay
{
    private readonly string _input;

    private const string testInput = """
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
        _input = File.ReadAllText(InputFilePath);

    private static void ProcessInput(string input)
    {
        var localInput = input.Replace("\n\r", "\n").Trim();
        var groups = localInput.Split("\n\n").Select(g => g.Trim()).ToList() ?? [];

        var seedsString = groups[0].Replace("seeds: ", string.Empty, StringComparison.OrdinalIgnoreCase).Trim();

        var seedsToSoilLines = GetRangeMaps(CleanGroup(groups[1]));
        var soilToFertilizerLines = GetRangeMaps(CleanGroup(groups[2]));
        var fertilizerToWaterLines = GetRangeMaps(CleanGroup(groups[3]));
        var waterToLightLines = GetRangeMaps(CleanGroup(groups[4]));
        var lightToTemperatureLines = GetRangeMaps(CleanGroup(groups[5]));
        var temperatureToHumidityLines = GetRangeMaps(CleanGroup(groups[6]));
        var humidityToLocationLines = GetRangeMaps(CleanGroup(groups[7]));

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
                if (!int.TryParse(destinationRangeStartString, out var destinationRangeStart))
                {
                    throw new Exception("Can't parse number");
                }

                var sourceRangeStartString = numStrings[1];
                if (!int.TryParse(sourceRangeStartString, out var sourceRangeStart))
                {
                    throw new Exception("Can't parse number");
                }

                var rangeLengthString = numStrings[2];
                if (!int.TryParse(rangeLengthString, out var rangeLength))
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
        ProcessInput(testInput);

        return new();
    }

    public override ValueTask<string> Solve_2() => new();

    private class RangeMap(int destinationRangeStart, int sourceRangeStart, int rangeLength)
    {
        public int DestinationRangeStart { get; } = destinationRangeStart;

        public int SourceRangeStart { get; } = sourceRangeStart;

        public int RangeLength { get; } = rangeLength;

        public Range DestinationRange => new(DestinationRangeStart, DestinationRangeStart + RangeLength);

        public Range SourceRange => new(SourceRangeStart, SourceRangeStart + RangeLength);
    }
}
