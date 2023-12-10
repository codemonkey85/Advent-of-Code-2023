namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/7
public class Day07 : BaseLibraryDay
{
    private readonly string _input;

    private const string testInput = """
        32T3K 765
        T55J5 684
        KK677 28
        KTJJT 220
        QQQJA 483
        """;

    public Day07() =>
        _input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1() => new();

    public override ValueTask<string> Solve_2() => new();
}
