namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/16
// ReSharper disable once UnusedType.Global
public sealed class Day16 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
                                     .|...\....
                                     |.-.\.....
                                     .....|-...
                                     ........|.
                                     ..........
                                     .........\
                                     ..../.\\..
                                     .-.-/..|..
                                     .|....-|.\
                                     ..//.|....
                                     """;

    public Day16() =>
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
