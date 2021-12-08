using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._08
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            return inputs
                .SelectMany(i => i
                    .Split(" | ")
                    .Last()
                    .Split(" "))
                .Count(i => i.Length == 2 || i.Length == 3 || i.Length == 4 || i.Length == 7);
        }
    }
}