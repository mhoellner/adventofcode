using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._03
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var counter = new int[inputs[0].Length];
            foreach (var input in inputs)
            {
                for (var i = 0; i < input.Length; i++)
                {
                    if (input[i] == '1')
                        counter[i] = counter[i] + 1;
                }
            }

            var binary = new string(counter.Select(c => c > inputs.Count / 2 ? '1' : '0').ToArray());
            var gamma = Convert.ToInt64(binary, 2);
            var inverseBinary = new string(counter.Select(c => c > inputs.Count / 2 ? '0' : '1').ToArray());
            var epsilon = Convert.ToInt64(inverseBinary, 2);

            return gamma * epsilon;
        }
    }
}