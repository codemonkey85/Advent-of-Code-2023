namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/22
// ReSharper disable once UnusedType.Global
public sealed class Day22 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
                                     1,0,1~1,2,1
                                     0,0,2~2,0,2
                                     0,2,3~2,2,3
                                     0,0,4~0,2,4
                                     2,0,5~2,2,5
                                     0,1,6~2,1,6
                                     1,1,8~1,1,9
                                     """;

    public Day22() =>
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
