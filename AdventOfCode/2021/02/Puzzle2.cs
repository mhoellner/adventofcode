using System.Collections.Generic;

namespace AdventOfCode._2021._02
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            long depth = 0;
            long position = 0;
            long aim = 0;

            foreach (var input in inputs)
            {
                var s = input.Split(" ");
                var command = s[0];
                var step = int.Parse(s[1]);
                if (command == "down")
                    aim += step;
                if (command == "up")
                    aim -= step;
                if (command == "forward")
                {
                    position += step;
                    depth += aim * step;
                }
            }

            return depth * position;
        }
    }
}