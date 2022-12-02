using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2022._02;

public class Puzzle2 : IPuzzle
{
    public long Resolve(List<string> inputs)
    {
        return inputs.Sum(CalculateScore);
    }

    private static int CalculateScore(string input)
    {
        return input switch
        {
            "A X" => 3, // 0+3
            "A Y" => 4, // 3+1
            "A Z" => 8, // 6+2
            "B X" => 1, // 0+1
            "B Y" => 5, // 3+2
            "B Z" => 9, // 6+3
            "C X" => 2, // 0+2
            "C Y" => 6, // 3+3
            "C Z" => 7, // 6+1
            _ => throw new ArgumentException("invalid input")
        };
    }
}