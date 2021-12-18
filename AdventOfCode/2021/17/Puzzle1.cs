using System.Collections.Generic;

namespace AdventOfCode._2021._17
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var y = int.Parse(inputs[0].Split("y=")[1].Split("..")[0]);
            return y * (y + 1) / 2;
        }
    }
}