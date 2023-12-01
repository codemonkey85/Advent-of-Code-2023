
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
        return new("");
    }
}
