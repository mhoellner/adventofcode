using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._17
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var s = inputs[0].Split(": x=")[1].Split(", y=");
            var targetX = s[0].Split("..").Select(int.Parse).ToArray();
            var targetY = s[1].Split("..").Select(int.Parse).ToArray();
            var counter = 0;
            for (var x = 0; x <= targetX[1]; x++)
            for (var y = targetY[0]; y <= targetY[0] * -1; y++)
                if (HitsTarget(targetX, targetY, x, y))
                    counter++;

            return counter;
        }

        private static bool HitsTarget(int[] targetX, int[] targetY, int x, int y)
        {
            var currentX = 0;
            var currentY = 0;
            while (currentX <= targetX[1] && currentY >= targetY[0])
            {
                if (currentX >= targetX[0] && currentY <= targetY[1])
                    return true;
                
                currentX += x;
                currentY += y;

                if (x > 0)
                    x -= 1;
                y -= 1;
            }

            return false;
        }
    }
}