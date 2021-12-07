using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._07
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var input = inputs[0].Split(",").Select(long.Parse).ToList();
            var minimum = input.Min();
            var maximum = input.Max();
            var cheapest = long.MaxValue;

            for (var current = minimum; current < maximum; current++)
            {
                var sum = input.Select(i => i > current ? i - current : current - i).Sum();
                if (sum < cheapest)
                    cheapest = sum;
            }

            return cheapest;
        }
    }
}