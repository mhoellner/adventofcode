using System.Collections.Generic;

namespace AdventOfCode._2020._03
{
    class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            return inputs.CountTrees(3, 1);
        }
    }
}
