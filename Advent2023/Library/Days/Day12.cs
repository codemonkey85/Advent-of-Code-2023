namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/12
// ReSharper disable once UnusedType.Global
public sealed class Day12 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
                                     #.#.### 1,1,3
                                     .#...#....###. 1,1,3
                                     .#.###.#.###### 1,3,1,6
                                     ####.#...#... 4,1,1
                                     #....######..#####. 1,6,5
                                     .###.##....# 3,2,1
                                     """;

    public Day12() =>
        input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        return new();
    }

    public override ValueTask<string> Solve_2()
    {
        return new();
    }
}
