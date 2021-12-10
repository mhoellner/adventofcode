using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._09
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var arr = new int[inputs.Count][];
            var riskLevels = new List<int>();
            for (var i = 0; i < inputs.Count; i++)
            {
                arr[i] = inputs[i].Select(c => int.Parse(c.ToString())).ToArray();
            }

            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = 0; j < arr[i].Length; j++)
                {
                    if (IsLowPoint(arr, i, j))
                        riskLevels.Add(arr[i][j] + 1);
                }
            }

            return riskLevels.Sum();
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