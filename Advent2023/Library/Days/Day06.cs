namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/6
// ReSharper disable once UnusedType.Global
public sealed class Day06 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
                                     Time:      7  15   30
                                     Distance:  9  40  200
                                     """;

    public Day06() =>
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
