namespace Advent2023.Library;

public class Day01 : BaseLibraryDay
{
    private readonly string _input;

    public Day01() =>
        _input = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        List<int> numbers = [];
        foreach (var line in _input.Split("\n"))
        {
            if (line is not { Length: > 0 })
            {
                continue;
            }

            var numberString = string.Empty;

            for (var i = 0; i < line.Length; i++)
            {
                var c = line[i];
                if (char.IsNumber(c))
                {
                    numberString += c;
                    break;
                }
            }

            for (var i = line.Length - 1; i >= 0; i--)
            {
                var c = line[i];
                if (char.IsNumber(c))
                {
                    numberString += c;
                    break;
                }
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
        /*
        Your calculation isn't quite right. It looks like some of
        the digits are actually spelled out with letters:
        one, two, three, four, five, six, seven, eight, and nine
        also count as valid "digits".

        Equipped with this new information, you now need to find
        the real first and last digit on each line. For example:

        two1nine
        eightwothree
        abcone2threexyz
        xtwone3four
        4nineeightseven2
        zoneight234
        7pqrstsixteen
        
        In this example, the calibration values are 29, 83, 13, 24,
        42, 14, and 76. Adding these together produces 281.

        What is the sum of all of the calibration values?
        */

        List<(string WordString, string DigitString)> digits = [
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

        foreach (var line in _input.Split("\n"))
        {
            if (line is not { Length: > 0 })
            {
                continue;
            }

            Dictionary<int, int> firstDigitDictionary = [];
            Dictionary<int, int> lastDigitDictionary = [];

            foreach (var (WordString, DigitString) in digits)
            {
                if (!int.TryParse(DigitString, out var digitValue))
                {
                    throw new Exception("Digit is not a number");
                }

                var firstIndexOfWord = line.IndexOf(WordString);
                var firstIndexOfDigit = line.IndexOf(DigitString);
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

                var lastIndexOfWord = line.LastIndexOf(WordString);
                var lastIndexOfDigit = line.LastIndexOf(DigitString);
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
