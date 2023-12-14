namespace Advent2023.Library.Days;

// https://adventofcode.com/2023/day/1
// ReSharper disable once UnusedType.Global
public sealed class Day01 : BaseLibraryDay
{
    private readonly string input;

    // ReSharper disable once UnusedMember.Local
    private const string TestInput = """
                                     1abc2
                                     pqr3stu8vwx
                                     a1b2c3d4e5f
                                     treb7uchet
                                     """;

    public Day01() =>
        input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        List<int> numbers = [];
        foreach (var line in input.Split("\n"))
        {
            if (line is not { Length: > 0 })
            {
                continue;
            }

            var numberString = string.Empty;

            foreach (var c in line.Where(char.IsNumber))
            {
                numberString += c;
                break;
            }

            for (var i = line.Length - 1; i >= 0; i--)
            {
                var c = line[i];
                if (!char.IsNumber(c))
                {
                    continue;
                }

                numberString += c;
                break;
            }

            if (int.TryParse(numberString, out var number))
            {
                numbers.Add(number);
            }
        }

        return new(numbers.Sum().ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        List<(string WordString, string DigitString)> digits =
        [
            ("one", "1"),
            ("two", "2"),
            ("three", "3"),
            ("four", "4"),
            ("five", "5"),
            ("six", "6"),
            ("seven", "7"),
            ("eight", "8"),
            ("nine", "9"),
        ];

        List<int> numbers = [];

        foreach (var line in input.Split("\n"))
        {
            if (line is not { Length: > 0 })
            {
                continue;
            }

            Dictionary<int, int> firstDigitDictionary = [];
            Dictionary<int, int> lastDigitDictionary = [];

            foreach (var (wordString, digitString) in digits)
            {
                if (!int.TryParse(digitString, out var digitValue))
                {
                    throw new Exception("Digit is not a number");
                }

                var firstIndexOfWord = line.IndexOf(wordString, StringComparison.Ordinal);
                var firstIndexOfDigit = line.IndexOf(digitString, StringComparison.Ordinal);
                var firstDigitIndices = new List<int> { firstIndexOfWord, firstIndexOfDigit };

                if (firstDigitIndices.All(index => index is -1))
                {
                    firstDigitDictionary.Add(digitValue, -1);
                }
                else
                {
                    var firstDigitIndex = firstDigitIndices
                        .Where(index => index is not -1)
                        .Min();

                    firstDigitDictionary.Add(digitValue, firstDigitIndex);
                }

                var lastIndexOfWord = line.LastIndexOf(wordString, StringComparison.Ordinal);
                var lastIndexOfDigit = line.LastIndexOf(digitString, StringComparison.Ordinal);
                var lastDigitIndices = new List<int> { lastIndexOfWord, lastIndexOfDigit };

                if (lastDigitIndices.All(index => index is -1))
                {
                    lastDigitDictionary.Add(digitValue, -1);
                }
                else
                {
                    var lastDigitIndex = lastDigitIndices
                        .Where(index => index is not -1)
                        .Max();

                    lastDigitDictionary.Add(digitValue, lastDigitIndex);
                }
            }

            var firstDigit = firstDigitDictionary
                .Where(digit => digit.Value is not -1)
                .MinBy(digit => digit.Value)
                .Key.ToString();

            var lastDigit = lastDigitDictionary
                .Where(digit => digit.Value is not -1)
                .MaxBy(digit => digit.Value)
                .Key.ToString();

            var numberString = firstDigit + lastDigit;

            if (!int.TryParse(numberString, out var number))
            {
                throw new Exception("Number is not a number");
            }

            if (number < 0)
            {
                throw new Exception("Number is negative");
            }

            numbers.Add(number);
        }

        return new(numbers.Sum().ToString());
    }
}