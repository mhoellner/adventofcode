using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._10
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var numbers = inputs.Select(int.Parse).OrderBy(i => i).ToList();
            var previous = 0;
            var oneCount = 0;
            var threeCount = 1;

            for (var i = 0; i < numbers.Count; i++)
            {
                var current = numbers[i];
                if (current - previous == 1)
                    oneCount++;
                else if (current - previous == 3)
                    threeCount++;
                else
                    throw new Exception();
                previous = current;
            }

            return oneCount * threeCount;
        }
    }
}
