namespace AdventOfCode2023.Day04;

public class Puzzle : IPuzzle
{
    public long ResolvePart1(List<string> input)
    {
        var sum = 0L;

        foreach (var card in input)
        {
            var values = card
                .Split(": ")[1]
                .Split(" | ")
                .Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                .ToArray();
            var amount = values[1]
                .Count(x => values[0].Contains(x));

            sum += amount < 2 ? amount : Convert.ToInt64(Math.Pow(2, amount - 1));
        }

        return sum;
    }

    public long ResolvePart2(List<string> input)
    {
        var cardCounter = new long[input.Count];
        for (var i = 0; i < input.Count; i++) cardCounter[i] = 1;

        for (var i = 0; i < input.Count; i++)
        {
            var card = input[i];
            var values = card
                .Split(": ")[1]
                .Split(" | ")
                .Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                .ToArray();
            var amount = values[1]
                .Count(x => values[0].Contains(x));

            for (var j = i; j < input.Count && j < i + amount; j++)
            {
                cardCounter[j + 1] += cardCounter[i];
            }
        }

        return cardCounter.Sum();
    }
}