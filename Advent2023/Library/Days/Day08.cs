namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/8
public class Day08 : BaseLibraryDay
{
    private readonly string _input;

    private const string testInput = """
        RL

        AAA = (BBB, CCC)
        BBB = (DDD, EEE)
        CCC = (ZZZ, GGG)
        DDD = (DDD, DDD)
        EEE = (EEE, EEE)
        GGG = (GGG, GGG)
        ZZZ = (ZZZ, ZZZ)
        """;

    public Day08() =>
        _input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1() => new();

    public override ValueTask<string> Solve_2() => new();
}
