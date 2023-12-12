namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/11
public class Day11 : BaseLibraryDay
{
    private readonly string _input;

    private const string testInput = """
        ...#......
        .......#..
        #.........
        ..........
        ......#...
        .#........
        .........#
        ..........
        .......#..
        #...#.....
        """;

    public Day11() =>
        _input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        return new();
    }

    public override ValueTask<string> Solve_2()
    {
        return new();
    }
}
