using System;
using System.Collections.Generic;

namespace AdventOfCode._2021._02
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            long depth = 0;
            long position = 0;
            foreach (var input in inputs)
            {
                var s = input.Split(" ");
                var command = s[0];
                var step = int.Parse(s[1]);
                if (command == "forward")
                    position += step;
                if (command == "down")
                    depth += step;
                if (command == "up")
                    depth -= step;
            }

            return depth * position;
        }
    }
}