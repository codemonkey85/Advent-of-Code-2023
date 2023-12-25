namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/25
// ReSharper disable once UnusedType.Global
public sealed class Day25 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
                                     jqt: rhn xhk nvd
                                     rsh: frs pzl lsr
                                     xhk: hfx
                                     cmg: qnr nvd lhk bvb
                                     rhn: xhk bvb hfx
                                     bvb: xhk hfx
                                     pzl: lsr hfx nvd
                                     qnr: nvd
                                     ntq: jqt hfx bvb xhk
                                     nvd: lhk
                                     lsr: lhk
                                     rzs: qnr cmg lsr rsh
                                     frs: qnr lhk lsr
                                     """;

    public Day25() =>
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
