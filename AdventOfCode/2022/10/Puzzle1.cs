using System.Collections.Generic;

namespace AdventOfCode._2022._10;

public class Puzzle1 : IPuzzle
{
    public long Resolve(List<string> inputs)
    {
        var register = 1;
        var cycle = 0;
        var result = 0;

        foreach (var input in inputs)
        {
            if (input == "noop")
            {
                cycle++;
                if (cycle % 40 == 20)
                    result += cycle * register;
                if (cycle == 220)
                    break;
            }
            if (input.StartsWith("addx"))
            {
                cycle++;
                if (cycle % 40 == 20)
                    result += cycle * register;
                if (cycle == 220)
                    break;
                cycle++;
                if (cycle % 40 == 20)
                    result += cycle * register;
                if (cycle == 220)
                    break;
                register += int.Parse(input.Split(' ')[1]);
            }
        }

        return result;
    }
}