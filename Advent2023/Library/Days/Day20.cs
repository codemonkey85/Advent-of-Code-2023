namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/20
// ReSharper disable once UnusedType.Global
public sealed class Day20 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
                                     broadcaster -> a, b, c
                                     %a -> b
                                     %b -> c
                                     %c -> inv
                                     &inv -> a
                                     """;

    public Day20() =>
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
