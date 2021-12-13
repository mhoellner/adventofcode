using System.Collections.Generic;
using System.Linq;
using Xunit.Abstractions;

namespace AdventOfCode._2021._13
{
    public class Puzzle2 : IPuzzle
    {
        private readonly ITestOutputHelper _outputHelper;

        public Puzzle2(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

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
                }
                else if (!string.IsNullOrEmpty(input))
                {
                    var coordinates = input.Split(",").Select(int.Parse).ToArray();
                    positions.Add(new Position(coordinates[0], coordinates[1]));
                }
            }

            PrintResult(positions.Distinct().ToList());

            return 0;
        }

        private void PrintResult(List<Position> positions)
        {
            var maxX = positions.Max(p => p.X);
            var maxY = positions.Max(p => p.Y);
            var array = new bool[maxY + 1][];
            for (var index = 0; index < array.Length; index++)
            {
                array[index] = new bool[maxX + 1];
            }

            foreach (var position in positions)
            {
                array[position.Y][position.X] = true;
            }

            foreach (var row in array)
            {
                _outputHelper.WriteLine(string.Join("", row.Select(b => b ? "#" : ".")));
            }
        }
    }
}