using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2022._01;

public class Puzzle1 : IPuzzle
{
    public long Resolve(List<string> inputs)
    {
        var maxCalories = 0L;
        var currentCalories = 0L;

        foreach (var input in inputs)
        {
            if (input == string.Empty)
            {
                if (currentCalories > maxCalories)
                    maxCalories = currentCalories;
                currentCalories = 0L;
            }
            else
            {
                currentCalories += long.Parse(input);
            }
        }

        return maxCalories;
    }
}