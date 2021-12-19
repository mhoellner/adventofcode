using System.Collections.Generic;

namespace AdventOfCode._2021._18
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var largest = 0;
            for (var index = 0; index < inputs.Count; index++)
            {
                for (var index2 = 0; index2 < inputs.Count; index2++)
                {
                    if (index2 == index)
                        continue;
                    var left = SnailfishNumber.Parse(inputs[index]);
                    var right = SnailfishNumber.Parse(inputs[index2]);
                    var sum = SnailfishNumber.Add(left, right).CalculateMagnitude();
                    if (sum > largest)
                        largest = sum;
                }
            }

            return largest;
        }
    }
}