using SelectionColor = (int Quantity, string Color);

namespace Advent2023.Library;

public class Day02 : BaseLibraryDay
{
    private readonly string _input;

    public Day02() =>
        _input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        const string red = "red";
        const string green = "green";
        const string blue = "blue";

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

        var games = _input.Split("\n");
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

        var gameIds = gamesResults
            .Where(game => game.Value.IsPossible)
            .Select(game => game.Key);

        return new(gameIds.Sum().ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        /*
        --- Part Two ---

        The Elf says they've stopped producing snow because they aren't getting any water!
        He isn't sure why the water stopped; however, he can show you how to get to the
        water source to check it out for yourself. It's just up ahead!

        As you continue your walk, the Elf poses a second question: in each game you played,
        what is the fewest number of cubes of each color that could have been in the bag
        to make the game possible?

        Again consider the example games from earlier:

        Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
        Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
        Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
        Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
        Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green

        In game 1, the game could have been played with as few as 4 red, 2 green, and 6 blue cubes.
        If any color had even one fewer cube, the game would have been impossible.
        
        Game 2 could have been played with a minimum of 1 red, 3 green, and 4 blue cubes.
        Game 3 must have been played with at least 20 red, 13 green, and 6 blue cubes.
        Game 4 required at least 14 red, 3 green, and 15 blue cubes.
        Game 5 needed no fewer than 6 red, 3 green, and 2 blue cubes in the bag.

        The power of a set of cubes is equal to the numbers of red, green, and blue cubes
        multiplied together. The power of the minimum set of cubes in game 1 is 48. In games
        2-5 it was 12, 1560, 630, and 36, respectively. Adding up these five powers produces
        the sum 2286.

        For each game, find the minimum set of cubes that must have been present. What is
        the sum of the power of these sets?
        */
        return new();
    }
}
