using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2022._03;

public class Puzzle1 : IPuzzle
{
    public long Resolve(List<string> inputs)
    {
        return inputs.Sum(FindDuplicatesPriority);
    }

    private static int FindDuplicatesPriority(string input)
    {
        var compartmentLength = input.Length / 2;
        var firstCompartment = input.AsSpan(0, compartmentLength);
        var secondCompartment = input.AsSpan(compartmentLength, compartmentLength);

        foreach (var item in firstCompartment)
            if (secondCompartment.Contains(item))
                return item > 96 ? item - 96 : item - 64 + 26;

        throw new ArgumentException("no common item found");
    }
}