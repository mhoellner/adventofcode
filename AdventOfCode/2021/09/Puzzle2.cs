using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._09
{
    public class Puzzle2 : IPuzzle
    {
        private int Max_X;
        private int Max_Y;
        public long Resolve(List<string> inputs)
        {
            var arr = new int[inputs.Count][];
            for (var i = 0; i < inputs.Count; i++)
            {
                arr[i] = inputs[i].Select(c => int.Parse(c.ToString())).ToArray();
            }

            var lowPoints = new List<Point>();
            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = 0; j < arr[i].Length; j++)
                {
                    if (IsLowPoint(arr, i, j))
                        lowPoints.Add(new Point(i, j, arr[i][j]));
                }
            }

            Max_X = arr.Length - 1;
            Max_Y = arr[0].Length - 1;
            var sizes = lowPoints.Select(lowPoint => GetBasinPoints(arr, lowPoint).Distinct().Count())
                .OrderByDescending(l => l)
                .ToList();

            return sizes[0] * sizes[1] * sizes[2];
        }

        private IEnumerable<Point> GetBasinPoints(int[][] arr, Point p)
        {
            var result = new List<Point> { p };
            if (p.X < Max_X)
            {
                var down = new Point(p.X + 1, p.Y, arr[p.X + 1][p.Y]);
                if (down.Value > p.Value && down.Value < 9)
                    result.AddRange(GetBasinPoints(arr, down));
            }

            if (p.X > 0)
            {
                var up = new Point(p.X - 1, p.Y, arr[p.X - 1][p.Y]);
                if (up.Value > p.Value && up.Value < 9)
                    result.AddRange(GetBasinPoints(arr, up));
            }

            if (p.Y < Max_Y)
            {
                var right = new Point(p.X, p.Y + 1, arr[p.X][p.Y + 1]);
                if (right.Value > p.Value && right.Value < 9)
                    result.AddRange(GetBasinPoints(arr, right));
            }

            if (p.Y > 0)
            {
                var left = new Point(p.X, p.Y - 1, arr[p.X][p.Y - 1]);
                if (left.Value > p.Value && left.Value < 9)
                    result.AddRange(GetBasinPoints(arr, left));
            }

            return result;
        }

        private static bool IsLowPoint(int[][] arr, int i, int j)
        {
            var current = arr[i][j];
            if (i > 0 && arr[i - 1][j] <= current)
                return false;
            if (i < arr.Length - 1 && arr[i + 1][j] <= current)
                return false;
            if (j > 0 && arr[i][j - 1] <= current)
                return false;
            if (j < arr[i].Length - 1 && arr[i][j + 1] <= current)
                return false;

            return true;
        }
    }
}