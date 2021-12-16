using System.Collections.Generic;

namespace AdventOfCode._2021._16
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var result = BitsParser.FindPackets(inputs);

            return result.SumVersions();
        }
    }
}