using System;
using System.Collections.Generic;

namespace AdventOfCode._2020._12
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var position = (0, 0);
            var orientation = "E";

            foreach (var input in inputs)
            {
                var instruction = input.Substring(0, 1);
                var amount = int.Parse(input.Substring(1));

                (int, int) MakeStep(string direction, int value)
                {
                    if (direction == "N")
                        return (position.Item1 + value, position.Item2);
                    if (direction == "S")
                        return (position.Item1 - value, position.Item2);
                    if (direction == "E")
                        return (position.Item1, position.Item2 + value);
                    if (direction == "W")
                        return (position.Item1, position.Item2 - value);
                    throw new ArgumentException("The direction is unknown", nameof(direction));
                }

                string ChangeOrientation(string rotation, int degrees, string current)
                {
                    if (degrees == 0)
                        return current;
                    if (rotation == "L")
                    {
                        var next = current == "N" ? "W"
                            : current == "W" ? "S"
                            : current == "S" ? "E"
                            : "N";

                        return ChangeOrientation(rotation, degrees - 90, next);
                    }
                    if (rotation == "R")
                    {
                        var next = current == "N" ? "E"
                            : current == "E" ? "S"
                            : current == "S" ? "W"
                            : "N";

                        return ChangeOrientation(rotation, degrees - 90, next);
                    }

                    throw new ArgumentException("The rotation is unknown", nameof(rotation));
                }

                if (instruction == "N" || instruction == "S" || instruction == "E" || instruction == "W")
                    position = MakeStep(instruction, amount);
                if (instruction == "F")
                    position = MakeStep(orientation, amount);
                if (instruction == "L" || instruction == "R")
                    orientation = ChangeOrientation(instruction, amount, orientation);
            }

            return Math.Abs(position.Item1) + Math.Abs(position.Item2);
        }
    }
}
