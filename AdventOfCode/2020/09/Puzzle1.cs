using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020._09
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var numbers = inputs.Select(long.Parse).ToList();
            for (var i = 25; i < numbers.Count; i++)
            {
                var input = numbers[i];
                var previousInputs = numbers.GetRange(i - 25, 25);
                if (MeetsCondition(input, previousInputs))
                    return input;
            }

            return 0;
        }

        private bool MeetsCondition(long currentInput, List<long> previousInputs)
        {
            for (var i = 0; i < previousInputs.Count; i++)
            {
                var diff = currentInput - previousInputs[i];

                if (diff == currentInput)
                    continue;

                if (previousInputs.Contains(diff))
                    return false;
            }

            return true;
        }
    }
}
