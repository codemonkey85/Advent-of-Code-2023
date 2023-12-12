namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/6
public class Day06 : BaseLibraryDay
{
    private readonly string _input;

    private const string testInput = """
        Time:      7  15   30
        Distance:  9  40  200
        """;

    public Day06() =>
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
