namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/17
// ReSharper disable once UnusedType.Global
public sealed class Day17 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
                                     2413432311323
                                     3215453535623
                                     3255245654254
                                     3446585845452
                                     4546657867536
                                     1438598798454
                                     4457876987766
                                     3637877979653
                                     4654967986887
                                     4564679986453
                                     1224686865563
                                     2546548887735
                                     4322674655533
                                     """;

    public Day17() =>
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
