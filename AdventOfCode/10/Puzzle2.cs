using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._10
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            inputs.Add("0");
            var numbers = inputs.Select(int.Parse).OrderBy(i => i).ToList();
            var permutations = new Dictionary<int, long> { { 0, 1 } };

            for (var i = 1; i < numbers.Count; i++)
            {
                var permutationAmount = permutations.GetValueOrDefault(numbers[i] - 1)
                    + permutations.GetValueOrDefault(numbers[i] - 2)
                    + permutations.GetValueOrDefault(numbers[i] - 3);

                permutations[numbers[i]] = permutationAmount;
            }

            return permutations[numbers.Last()];
        }
    }
}
