using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2022._04;

public class Puzzle1 : IPuzzle
{
    public long Resolve(List<string> inputs)
    {
        return inputs.Count(OneFullyContainsTheOther);
    }

    private static bool OneFullyContainsTheOther(string input)
    {
        var sections = input.Split(',').SelectMany(elf => elf.Split('-').Select(int.Parse)).ToArray();

        return sections[0] <= sections[2] && sections[1] >= sections[3] || sections[0] >= sections[2] && sections[1] <= sections[3];
    }
}