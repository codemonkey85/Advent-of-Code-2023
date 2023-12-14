namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/14
// ReSharper disable once UnusedType.Global
public sealed class Day14 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
                                     O....#....
                                     O.OO#....#
                                     .....##...
                                     OO.#O....O
                                     .O.....O#.
                                     O.#..O.#.#
                                     ..O..#O..O
                                     .......O..
                                     #....###..
                                     #OO..#....
                                     """;

    public Day14() =>
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
