using System.Collections.Generic;

namespace AdventOfCode._03
{
    class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            return inputs.CountTrees(1, 1) * inputs.CountTrees(3, 1) * inputs.CountTrees(5, 1) * inputs.CountTrees(7, 1) * inputs.CountTrees(1, 2);
        }
    }
}
