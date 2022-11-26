using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020._01
{
    public class Puzzle2 : IPuzzle
    {
        private readonly int Target;

        public Puzzle2(int target = 2020)
        {
            Target = target;
        }

        public long Resolve(List<string> input)
        {
            var parsedInput = input.Select(int.Parse).OrderBy(a => a).ToList();

            for (var i = 0; i < parsedInput.Count - 2;)
            {
                var left = i + 1;
                var right = parsedInput.Count - 1;
                var sum = 0;
                while (sum != Target)
                {
                    sum = parsedInput[left] + parsedInput[right] + parsedInput[i];

                    if (sum < Target)
                        left++;
                    else if (sum > Target)
                        right--;
                }

                return parsedInput[left] * parsedInput[right] * parsedInput[i];
            }

            return 0;
        }
    }
}
