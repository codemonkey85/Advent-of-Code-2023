namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/7
// ReSharper disable once UnusedType.Global
public sealed class Day07 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
                                     32T3K 765
                                     T55J5 684
                                     KK677 28
                                     KTJJT 220
                                     QQQJA 483
                                     """;

    public Day07() =>
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
