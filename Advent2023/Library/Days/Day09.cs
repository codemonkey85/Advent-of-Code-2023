namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/9
// ReSharper disable once UnusedType.Global
public sealed class Day09 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
                                     0 3 6 9 12 15
                                     1 3 6 10 15 21
                                     10 13 16 21 30 45
                                     """;

    public Day09() =>
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
