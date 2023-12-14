namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/4
// ReSharper disable once UnusedType.Global
public sealed class Day04 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
                                     Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
                                     Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
                                     Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
                                     Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
                                     Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
                                     Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
                                     """;

    public Day04() =>
        input = File.ReadAllText(InputFilePath);

    private Dictionary<int, Card> GetCards(string input)
    {
        Dictionary<int, Card> cards = [];
        var localInput = input.Replace("\n\r", "\n");
        var lines = localInput.Split('\n') ?? [];
        foreach (var line in lines.Select(l => l.Trim()).Where(l => !string.IsNullOrEmpty(l)))
        {
            var cardLineSplit = line.Split(':').Select(l => l.Trim()).ToList() ?? [];
            var cardNumString = cardLineSplit[0].Replace("Card", string.Empty, StringComparison.OrdinalIgnoreCase).Trim();

            if (!int.TryParse(cardNumString, out var cardNum))
            {
                throw new Exception("Can't parse card number");
            }

            var cardNumberStrings = cardLineSplit[1].Split('|').Select(c => c.Trim()).ToList() ?? [];
            var winningNumbers = ConvertNumStringsToNumList(cardNumberStrings[0]) ?? [];
            var myNumbers = ConvertNumStringsToNumList(cardNumberStrings[1]) ?? [];

            cards.Add(cardNum, new Card
            {
                CardNum = cardNum,
                WinningNumbers = winningNumbers,
                MyNumbers = myNumbers,
            });
        }

        return cards;

        static List<int> ConvertNumStringsToNumList(string numStrings) => numStrings
                .Split(' ')
                .Select(c => c.Trim())
                .Where(c => !string.IsNullOrEmpty(c) && !string.IsNullOrWhiteSpace(c))
                .Select(c => !int.TryParse(c, out var num) ? throw new Exception("Invalid Number") : num)
                .Order()
                .ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        var cardsDictionary = GetCards(input)
            .Select(kvp => kvp.Value);

        return new(cardsDictionary.Sum(c => c.TotalPoints).ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        var cardsDictionary = GetCards(input);
        List<Card> allCards = [];

        foreach (var (key, card) in cardsDictionary)
        {
            allCards.Add(card);

            if (card.TotalMatchingNumbers == 0)
            {
                continue;
            }

            var moreCards = GetMoreCards(cardsDictionary, key, card);
            allCards.AddRange(moreCards);
        }

        return new(allCards.Count.ToString());

        static List<Card> GetMoreCards(
            Dictionary<int, Card> cardsDictionary,
            int key,
            Card card)
        {
            List<Card> results = [];

            for (var index = 1; index <= card.TotalMatchingNumbers; index++)
            {
                var newKey = key + index;
                if (!cardsDictionary.TryGetValue(newKey, out var newCard))
                {
                    throw new Exception("Card not found");
                }
                results.Add(newCard);
                var moreCards = GetMoreCards(cardsDictionary, newKey, newCard);
                results.AddRange(moreCards);
            }

            return results;
        }
    }

    private class Card()
    {
        public int CardNum { get; set; }

        public List<int> WinningNumbers { get; set; } = [];

        public List<int> MyNumbers { get; set; } = [];

        public int TotalPoints
        {
            get
            {
                if (TotalMatchingNumbers == 0)
                {
                    return 0;
                }

                var totalPoints = 1;

                for (var i = 0; i < TotalMatchingNumbers - 1; i++)
                {
                    totalPoints *= 2;
                }

                return totalPoints;
            }
        }

        public int TotalMatchingNumbers =>
            WinningNumbers.Count == 0 || MyNumbers.Count == 0
                    ? 0
                    : MyNumbers
            .Count(n => WinningNumbers.Contains(n));

        public override string ToString() =>
            $"{nameof(CardNum)}: {CardNum}, " +
            $"{nameof(TotalMatchingNumbers)}: {TotalMatchingNumbers}, ";
    }
}
