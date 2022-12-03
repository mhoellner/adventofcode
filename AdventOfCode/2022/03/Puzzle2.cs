using System;
using System.Collections.Generic;

namespace AdventOfCode._2022._03;

public class Puzzle2 : IPuzzle
{
    public long Resolve(List<string> inputs)
    {
        var sum = 0;
        for (var index = 0; index < inputs.Count; index += 3)
            sum += FindDuplicatesPriority(inputs[index], inputs[index + 1], inputs[index + 2]);

        return sum;
    }

    private static int FindDuplicatesPriority(string firstInput, string secondInput, string thirdInput)
    {
        var first = firstInput.AsSpan();
        var second = secondInput.AsSpan();
        var third = thirdInput.AsSpan();
        foreach (var item in first)
            if (second.Contains(item) && third.Contains(item))
                return item > 96 ? item - 96 : item - 64 + 26;

        throw new ArgumentException("no common item found");
    }
}