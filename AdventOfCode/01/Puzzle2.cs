using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._01
{
    public class Puzzle2 : IPuzzle
    {
        private readonly int Target;

        public Puzzle2(int target = 2020)
        {
            Target = target;
        }

        public int Resolve(List<string> input)
        {
            var parsedInput = input.Select(int.Parse).OrderBy(a => a).ToList();
            var left = 0;
            var right = parsedInput.Count - 1;
            var sum = 0;

            for (var i = 0; i < parsedInput.Count - 2; i++)
            {
                left = i + 1;
                right = parsedInput.Count - 1;
                sum = 0;
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
