namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/3
// ReSharper disable once UnusedType.Global
public sealed class Day03 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
                                     467..114..
                                     ...*......
                                     ..35..633.
                                     ......#...
                                     617*......
                                     .....+.58.
                                     ..592.....
                                     ......755.
                                     ...$.*....
                                     .664.598..
                                     """;

    public Day03() =>
        input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        /*
        The engineer explains that an engine part seems
        to be missing from the engine, but nobody can
        figure out which one. If you can add up all
        the part numbers in the engine schematic,
        it should be easy to work out which part is
        missing.

        The engine schematic (your puzzle input)
        consists of a visual representation of the
        engine. There are lots of numbers and symbols
        you don't really understand, but apparently
        any number adjacent to a symbol, even
        diagonally, is a "part number" and should
        be included in your sum.
        (Periods (.) do not count as a symbol.)

        Here is an example engine schematic:

        467..114..
        ...*......
        ..35..633.
        ......#...
        617*......
        .....+.58.
        ..592.....
        ......755.
        ...$.*....
        .664.598..

        In this schematic, two numbers are not part numbers
        because they are not adjacent to a symbol:
        114 (top right) and 58 (middle right). Every other
        number is adjacent to a symbol and so is a part
        number; their sum is 4361.

        Of course, the actual engine schematic is much
        larger. What is the sum of all of the part
        numbers in the engine schematic?
        */

        var lines = TestInput
            .Replace("\r\n", "\n")
            .Split('\n')
            .Where(line => line.Trim() is { Length: > 0 })
            .ToList();

        for (var lineNum = 0; lineNum < lines.Count; lineNum++)
        {
            if (lineNum is 0)
            {
                var theseLines = lines[..2];
                var line1 = theseLines[0];
                var line2 = theseLines[1];

                List<int> line1NumIndices = [];
                List<int> line2NumIndices = [];

                for (var charNum = 0; charNum < line1.Length; charNum++)
                {
                    if (char.IsNumber(line1[charNum]))
                    {
                        line1NumIndices.Add(charNum);
                    }
                }
            }
            else if (lineNum == lines.Count - 1)
            {
                var theseLines = lines[^2..];
                var line1 = theseLines[0];
                var line2 = theseLines[1];
            }
            else
            {
                var theseLines = lines[(lineNum - 1)..(lineNum + 2)];
                var line1 = theseLines[0];
                var line2 = theseLines[1];
                var line3 = theseLines[2];
            }
        }

        return new();
    }

    public override ValueTask<string> Solve_2()
    {
        return new();
    }
}
