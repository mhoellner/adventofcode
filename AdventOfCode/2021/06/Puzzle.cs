using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._06
{
    public class Puzzle : IPuzzle
    {
        private readonly int _target;

        public Puzzle(int target)
        {
            _target = target;
        }

        public long Resolve(List<string> inputs)
        {
            var fishList = inputs[0].Split(",").Select(int.Parse);
            var counter = new long[9];
            foreach (var fish in fishList)
            {
                counter[fish] += 1;
            }

            return Grow(counter, 0);
        }

        private long Grow(long[] counter, int day)
        {
            while (day < _target)
            {
                var temp = counter[0];
                for (var index = 1; index < counter.Length; index++)
                {
                    counter[index - 1] = counter[index];
                }

                counter[6] += temp;
                counter[8] = temp;

                day += 1;
            }

            return counter.Sum();
        }
    }
}