using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode._2021._22
{
    public class Puzzle : IPuzzle
    {
        private readonly bool _isPart1;

        public Puzzle(bool isPart1 = true)
        {
            _isPart1 = isPart1;
        }

        public long Resolve(List<string> inputs)
        {
            var result = new List<Cuboid>();
            foreach (var input in inputs)
            {
                var array = Regex.Matches(input, @"-*\d+").Select(match => int.Parse(match.Value)).ToArray();
                var cuboid = new Cuboid(array, input.StartsWith("on"));
                if (_isPart1 && !cuboid.IsSmall())
                    continue;
                result.AddRange(result
                    .Select(c => Cuboid.Intersect(c, cuboid))
                    .Where(c => c != null)
                    .ToList());
                if (cuboid.On)
                    result.Add(cuboid);
            }

            return result.Sum(c => c.CalculateVolume());
        }
    }
}