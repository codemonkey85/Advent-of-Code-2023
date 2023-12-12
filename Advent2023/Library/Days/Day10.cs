﻿namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/10
public class Day10 : BaseLibraryDay
{
    private readonly string _input;

    private const string testInput = """
        .....
        .S-7.
        .|.|.
        .L-J.
        .....
        """;

    public Day10() =>
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
