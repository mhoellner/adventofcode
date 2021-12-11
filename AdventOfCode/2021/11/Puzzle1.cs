using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._11
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var array = new DumboOctopus[inputs.Count][];
            for (var i = 0; i < inputs.Count; i++)
                array[i] = inputs[i].Select(c => new DumboOctopus(int.Parse(c.ToString()))).ToArray();

            return CalculateFlashes(array, 100);
        }

        private long CalculateFlashes(DumboOctopus[][] array, int step)
        {
            if (step == 0)
                return 0;

            for (var i = 0; i < array.Length; i++)
            for (var j = 0; j < array[i].Length; j++)
                array[i][j].NextStep();
            
            while (!HaveAllFlashed(array))
            {
                for (var i = 0; i < array.Length; i++)
                for (var j = 0; j < array[i].Length; j++)
                    if (array[i][j].Energy > 9)
                    {
                        array[i][j].Flash();
                        foreach (var adjacentOctopus in AdjacentOctopuses(array, i, j))
                            adjacentOctopus.Touch();
                    }
            }

            var flashes = array.Sum(row => row.Count(octopus => octopus.Energy == 0));

            return flashes + CalculateFlashes(array, step - 1);
        }

        private static bool HaveAllFlashed(DumboOctopus[][] array)
        {
            return array.All(row => !row.Any(octopus => octopus.Energy > 9));
        }

        private static IEnumerable<DumboOctopus> AdjacentOctopuses(DumboOctopus[][] array, int i, int j)
        {
            var result = new List<DumboOctopus>();
            for (var x = i - 1; x <= i + 1; x++)
            for (var y = j - 1; y <= j + 1; y++)
                if (x >= 0 && x < array.Length && y >= 0 && y < array[0].Length && !(x == i && y == j))
                    result.Add(array[x][y]);

            return result;
        }
    }
}