﻿namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/8
// ReSharper disable once UnusedType.Global
public sealed class Day08 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
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
