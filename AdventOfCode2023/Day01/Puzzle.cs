namespace AdventOfCode2023.Day01;

public class Puzzle : IPuzzle
{
    public long ResolvePart1(List<string> input)
    {
        return input.Aggregate(0L, (current, value) => current + int.Parse($"{value.First("123456789".Contains)}{value.Last("123456789".Contains)}"));
    }

    public long ResolvePart2(List<string> input)
    {
        var sum = 0L;
        foreach (var part in input)
        {
            var digits = new[] {'0', '0'};
            var isFirst = true;

            for (var i = 0; i < part.Length; i++)
            {
                if (int.TryParse(part[i].ToString(), out _))
                {
                    digits[isFirst ? 0 : 1] = part[i];
                    isFirst = false;
                }

                var sub = part[i..];
                if (sub.StartsWith("one"))
                {
                    digits[isFirst ? 0 : 1] = '1';
                    isFirst = false;
                }
                else if (sub.StartsWith("two"))
                {
                    digits[isFirst ? 0 : 1] = '2';
                    isFirst = false;
                }
                else if (sub.StartsWith("three"))
                {
                    digits[isFirst ? 0 : 1] = '3';
                    isFirst = false;
                }
                else if (sub.StartsWith("four"))
                {
                    digits[isFirst ? 0 : 1] = '4';
                    isFirst = false;
                }
                else if (sub.StartsWith("five"))
                {
                    digits[isFirst ? 0 : 1] = '5';
                    isFirst = false;
                }
                else if (sub.StartsWith("six"))
                {
                    digits[isFirst ? 0 : 1] = '6';
                    isFirst = false;
                }
                else if (sub.StartsWith("seven"))
                {
                    digits[isFirst ? 0 : 1] = '7';
                    isFirst = false;
                }
                else if (sub.StartsWith("eight"))
                {
                    digits[isFirst ? 0 : 1] = '8';
                    isFirst = false;
                }
                else if (sub.StartsWith("nine"))
                {
                    digits[isFirst ? 0 : 1] = '9';
                    isFirst = false;
                }
            }

            if (digits[1] == '0')
                digits[1] = digits[0];

            sum += int.Parse(digits);
        }

        return sum;
    }
}