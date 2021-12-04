using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020._01
{
    public class Puzzle1 : IPuzzle
    {
        private readonly int Target;

        public Puzzle1(int target = 2020)
        {
            Target = target;
        }

        public long Resolve(List<string> input)
        {
            var parsedInput = input.Select(int.Parse).ToList();
            parsedInput.Sort();
            var lowerIndex = 0;
            var upperIndex = input.Count - 1;
            int sum = 0;

            while (sum != Target)
            {
                if (lowerIndex == upperIndex)
                    return 0;

                sum = parsedInput[lowerIndex] + parsedInput[upperIndex];

                if (sum < Target)
                    lowerIndex++;
                else if (sum > Target)
                    upperIndex--;
            }

            return parsedInput[lowerIndex] * parsedInput[upperIndex];
        }
    }
}
