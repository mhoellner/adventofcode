using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2022._06;

public class Puzzle : IPuzzle
{
    private readonly int _sequenceLength;

    public Puzzle(int sequenceLength = 4)
    {
        _sequenceLength = sequenceLength;
    }

    public long Resolve(List<string> inputs)
    {
        var input = inputs.First();
        for (var index = 0; index < input.Length; index++)
        {
            if (CharsAreUnique(input.Substring(index, _sequenceLength)))
                return index + _sequenceLength;
        }

        throw new ArgumentException("no unique char sequence found");
    }

    private bool CharsAreUnique(string input) => input.Select(c => c).Distinct().Count() == _sequenceLength;
}