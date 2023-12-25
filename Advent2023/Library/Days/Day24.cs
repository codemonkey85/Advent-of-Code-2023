namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/24
// ReSharper disable once UnusedType.Global
public sealed class Day24 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
                                     19, 13, 30 @ -2,  1, -2
                                     18, 19, 22 @ -1, -1, -2
                                     20, 25, 34 @ -2, -2, -4
                                     12, 31, 28 @ -1, -2, -1
                                     20, 19, 15 @  1, -5, -3
                                     """;

    public Day24() =>
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
