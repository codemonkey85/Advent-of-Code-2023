namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/12
public class Day12 : BaseLibraryDay
{
    private readonly string _input;

    private const string testInput = """
        #.#.### 1,1,3
        .#...#....###. 1,1,3
        .#.###.#.###### 1,3,1,6
        ####.#...#... 4,1,1
        #....######..#####. 1,6,5
        .###.##....# 3,2,1
        """;

    public Day12() =>
        _input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        return new();
    }

    public override ValueTask<string> Solve_2()
    {
        return new();
    }
}
