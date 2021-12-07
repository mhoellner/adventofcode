using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._07
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var input = inputs[0].Split(",").Select(int.Parse).ToList();
            var minimum = input.Min();
            var maximum = input.Max();
            var cheapest = long.MaxValue;

            for (var current = minimum; current < maximum; current++)
            {
                var sum = 0L;
                foreach (var i in input)
                {
                    var range = Enumerable.Range(0, i > current ? i - current : current - i);
                    var aggregate = range.Aggregate(0L, (previous, next) => previous + next + 1);
                    sum += aggregate;
                }
                if (sum < cheapest)
                    cheapest = sum;
            }

            return cheapest;
        }
    }
}