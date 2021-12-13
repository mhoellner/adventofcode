using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._13
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var positions = new List<Position>();
            foreach (var input in inputs)
            {
                if (input.StartsWith("fold along"))
                {
                    for (var index = 0; index < positions.Count; index++)
                    {
                        var s = input.Split("=");
                        if (s[0].EndsWith("x"))
                            positions[index].FoldX(int.Parse(s[1]));
                        else positions[index].FoldY(int.Parse(s[1]));
                    }

                    return positions.Distinct().Count();
                }
                if (!string.IsNullOrEmpty(input))
                {
                    var coordinates = input.Split(",").Select(int.Parse).ToArray();
                    positions.Add(new Position(coordinates[0], coordinates[1]));
                }
            }

            return 0;
        }
    }
}