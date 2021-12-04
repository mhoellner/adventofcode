using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020._09
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var numbers = inputs.Select(long.Parse).ToList();
            for (var i = 0; i < numbers.Count; i++)
            {
                if (MeetsCondition(numbers.GetRange(i, numbers.Count - i), out var result))
                    return result;
            }

            return 0;
        }

        private const long Target = 50047984L;

        private bool MeetsCondition(List<long> remaining, out long result)
        {
            var sum = 0L;
            result = 0;
            for (var i = 0; i < remaining.Count; i++)
            {
                sum += remaining[i];

                if (sum == Target)
                {
                    var range = remaining.GetRange(0, i + 1);
                    result = range.Min() + range.Max();
                    return true;
                }

                if (sum > Target)
                    return false;
            }

            return false;
        }
    }
}
