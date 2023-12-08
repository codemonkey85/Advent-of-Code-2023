using SelectionColor = (int Quantity, string Color);

namespace Advent2023.Library;

// https://adventofcode.com/2023/day/2
public class Day02 : BaseLibraryDay
{
    private readonly string _input;

    public Day02() =>
        _input = File.ReadAllText(InputFilePath);

    private const string red = "red";
    private const string green = "green";
    private const string blue = "blue";

    public override ValueTask<string> Solve_1()
    {
        var gamesResults = GetGameResults(_input);

        var gameIds = gamesResults
            .Where(game => game.Value.IsPossible)
            .Select(game => game.Key);

        return new(gameIds.Sum().ToString());
    }

    private Dictionary<int, (List<List<SelectionColor>> Pulls, bool IsPossible)>
        GetGameResults(string input)
    {
        const int maxRed = 12;
        const int maxGreen = 13;
        const int maxBlue = 14;

        Dictionary<string, int> colorMaxes = new()
        {
            { red, maxRed },
            { green, maxGreen},
            { blue, maxBlue },
        };

        Dictionary<int, (List<List<SelectionColor>> Pulls, bool IsPossible)> gamesResults = [];

        var games = input.Split("\n");
        foreach (var game in games.Where(g => g is { Length: > 0 }))
        {
            var gameStrings = game.Split(':').Select(gs => gs.Trim());
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
                    var selectionSplit = selection.Split(" ").Select(s => s.Trim());
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
                    if (!colorMaxes.ContainsKey(color))
                    {
                        throw new Exception("Color not found!");
                    }
                    if (quantity > colorMaxes[color])
                    {
                        isGamePossible = false;
                        break;
                    }
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
        var gamesResults = GetGameResults(_input);
        List<int> gamePowers = [];

        foreach (var gameResults in gamesResults)
        {
            var gameId = gameResults.Key;
            var (pulls, _) = gameResults.Value;

            var minRed = GetMinColor(pulls, red);
            var minGreen = GetMinColor(pulls, green);
            var minBlue = GetMinColor(pulls, blue);

            var gamePower = minRed * minGreen * minBlue;
            gamePowers.Add(gamePower);
        }

        return new(gamePowers.Sum().ToString());

        static int GetMinColor(List<List<SelectionColor>> pulls, string color) =>
            pulls.SelectMany(p => p.Where(p => p.Color is red)).MaxBy(p => p.Quantity).Quantity;
    }
}
