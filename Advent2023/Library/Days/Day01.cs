
namespace Advent2023.Library;

public class Day01 : BaseLibraryDay
{
    private string _input;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
    }

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

        List<int> numbers = [];
        foreach (var line in _input.Split("\n"))
        {
            if (line is not { Length: > 0 })
            {
                continue;
            }

            var numberString = string.Empty;

            if (int.TryParse(numberString, out var number))
            {
                numbers.Add(number);
            }
        }
        return new(numbers.Sum().ToString());
    }
}
