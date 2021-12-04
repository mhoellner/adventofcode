using System;
using System.Collections.Generic;

namespace AdventOfCode._2020._12
{
    public class Puzzle2 : IPuzzle
    {
        private (int, int) Position;
        private (int, int) Waypoint;
        public long Resolve(List<string> inputs)
        {
            Position = (0, 0);
            Waypoint = (1, 10);

            foreach (var input in inputs)
            {
                var instruction = input.Substring(0, 1);
                var amount = int.Parse(input.Substring(1));

                if (instruction == "N" || instruction == "S" || instruction == "E" || instruction == "W")
                    AdjustWaypoint(instruction, amount);
                if (instruction == "F")
                    Move(amount);
                if (instruction == "L" || instruction == "R")
                    RotateWaypoint(instruction, amount);
            }

            return Math.Abs(Position.Item1) + Math.Abs(Position.Item2);
        }

        private void AdjustWaypoint(string direction, int amount)
        {
            if (direction == "N")
                Waypoint = (Waypoint.Item1 + amount, Waypoint.Item2);
            if (direction == "S")
                Waypoint = (Waypoint.Item1 - amount, Waypoint.Item2);
            if (direction == "E")
                Waypoint = (Waypoint.Item1, Waypoint.Item2 + amount);
            if (direction == "W")
                Waypoint = (Waypoint.Item1, Waypoint.Item2 - amount);
        }

        private void Move(int amount)
        {
            Position = (Position.Item1 + (Waypoint.Item1 * amount), Position.Item2 + (Waypoint.Item2 * amount));
        }

        private void RotateWaypoint(string direction, int amount)
        {
            if (amount == 0)
                return;
            if (direction == "R")
                Waypoint = (-Waypoint.Item2, Waypoint.Item1);
            if (direction == "L")
                Waypoint = (Waypoint.Item2, -Waypoint.Item1);
            RotateWaypoint(direction, amount - 90);
        }
    }
}
