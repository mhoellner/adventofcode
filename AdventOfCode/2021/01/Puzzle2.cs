using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._01
{
    public class Puzzle2 : IPuzzle
    {
        private long currentMaxSum = 0;
        private int counter = 0;
        public long Resolve(List<string> inputs)
        {
            return Resolve(inputs.Select(int.Parse).ToList());
        }

        private long Resolve(List<int> inputs)
        {
            currentMaxSum = inputs[0] + inputs[1] + inputs[2];

            for (var i = 3; i < inputs.Count; i++)
            {
                var sum = inputs[i] + inputs[i - 1] + inputs[i - 2];
                if (sum > currentMaxSum)
                {
                    counter++;
                }

                currentMaxSum = sum;
            }

            return counter;
        }
    }
}