using SelectionColor = (int Quantity, string Color);

namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/2
// ReSharper disable once UnusedType.Global
public sealed class Day02 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
                                     Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
                                     Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
                                     Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
                                     Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
                                     Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
                                     """;

    public Day02() =>
        input = File.ReadAllText(InputFilePath);

    private const string Red = "red";
    private const string Green = "green";
    private const string Blue = "blue";

    public override ValueTask<string> Solve_1()
    {
        var gamesResults = GetGameResults(input);

        var gameIds = gamesResults
            .Where(game => game.Value.IsPossible)
            .Select(game => game.Key);

        return new(gameIds.Sum().ToString());
    }

    private static Dictionary<int, (List<List<SelectionColor>> Pulls, bool IsPossible)>
        GetGameResults(string input)
    {
        const int maxRed = 12;
        const int maxGreen = 13;
        const int maxBlue = 14;

        Dictionary<string, int> colorMaxes = new() { { Red, maxRed }, { Green, maxGreen }, { Blue, maxBlue }, };

        Dictionary<int, (List<List<SelectionColor>> Pulls, bool IsPossible)> gamesResults = [];

        var games = input.Split("\n");
        foreach (var game in games.Where(g => g is { Length: > 0 }))
        {
            var gameStrings = game.Split(':').Select(gs => gs.Trim()).ToList();
            var gameString = gameStrings.First().Replace("Game ", string.Empty);

            if (!int.TryParse(gameString, out var gameNumber))
            {
                throw new Exception("Game number not found!");
            }

            List<List<SelectionColor>> gameResults = [];
            var isGamePossible = true;

            var pullStrings = gameStrings.Last().Trim().Split(";").Select(p => p.Trim());
            foreach (var pullString in pullStrings)
            {
                var selectionStrings = pullString.Split(",").Select(p => p.Trim());
                List<SelectionColor> selectionColors = [];
                foreach (var selection in selectionStrings)
                {
                    var selectionSplit = selection.Split(" ").Select(s => s.Trim()).ToList();
                    var quantityString = selectionSplit.First();
                    if (!int.TryParse(quantityString, out var quantity))
                    {
                        throw new Exception("Quantity invalid!");
                    }

                    var color = selectionSplit.Last().ToLower();

                    selectionColors.Add((quantity, color));
                }

                gameResults.Add(selectionColors);
            }

            foreach (var g in gameResults)
            {
                foreach (var (quantity, color) in g)
                {
                    if (!colorMaxes.TryGetValue(color, out var colorInt))
                    {
                        throw new Exception("Color not found!");
                    }

                    if (quantity <= colorInt)
                    {
                        continue;
                    }

                    isGamePossible = false;
                    break;
                }

                if (!isGamePossible)
                {
                    break;
                }
            }

            gamesResults.Add(gameNumber, (gameResults, isGamePossible));
        }

        return gamesResults;
    }

    public override ValueTask<string> Solve_2()
    {
        var gamesResults = GetGameResults(input);
        List<int> gamePowers = [];

        foreach (var gameResults in gamesResults)
        {
            var (pulls, _) = gameResults.Value;

            var minRed = GetMinColor(pulls);
            var minGreen = GetMinColor(pulls);
            var minBlue = GetMinColor(pulls);

            var gamePower = minRed * minGreen * minBlue;
            gamePowers.Add(gamePower);
        }

        return new(gamePowers.Sum().ToString());

        static int GetMinColor(List<List<SelectionColor>> pulls) =>
            pulls.SelectMany(p => p.Where(p1 => p1.Color is Red)).MaxBy(p => p.Quantity).Quantity;
    }
}