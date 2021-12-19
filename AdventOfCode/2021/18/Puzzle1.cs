using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._18
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var numbers = inputs.Select(SnailfishNumber.Parse);
            SnailfishNumber result = null;
            foreach (var number in numbers)
            {
                result = SnailfishNumber.Add(result, number);
            }

            return result!.CalculateMagnitude();
        }
    }
}