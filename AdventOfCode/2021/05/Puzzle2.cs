using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._05
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var field = CreateField();

            foreach (var input in inputs)
            {
                var points = input
                    .Split(" -> ")
                    .Select(coordinate => coordinate
                        .Split(",")
                        .Select(int.Parse)
                        .ToArray())
                    .ToArray();
                var x1 = points[0][0];
                var y1 = points[0][1];
                var x2 = points[1][0];
                var y2 = points[1][1];

                MarkFields(field, x1, y1, x2, y2);
            }

            return CountOverlaps(field);
        }

        private static long CountOverlaps(int[][] field)
        {
            return field.SelectMany(row => row).LongCount(point => point > 1);
        }

        private static void MarkFields(int[][] field, int x1, int y1, int x2, int y2)
        {
            var xRange = (x1 < x2 ? Enumerable.Range(x1, x2 - x1 + 1) : Enumerable.Range(x2, x1 - x2 + 1).Reverse()).ToList();
            var yRange = (y1 < y2 ? Enumerable.Range(y1, y2 - y1 + 1) : Enumerable.Range(y2, y1 - y2 + 1).Reverse()).ToList();

            if (x1 == x2 || y1 == y2)
                foreach (var x in xRange)
                foreach (var y in yRange)
                    field[x][y] += 1;
            else
                for (var i = 0; i < xRange.Count; i++)
                {
                    var x = xRange[i];
                    var y = yRange[i];
                    field[x][y] += 1;
                }
        }

        private static int[][] CreateField()
        {
            var field = new int[1000][];
            for (var i = 0; i < 1000; i++)
                field[i] = new int[1000];

            return field;
        }
    }
}