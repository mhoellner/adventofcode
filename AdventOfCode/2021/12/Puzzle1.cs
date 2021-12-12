using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._12
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var graph = new Graph();
            foreach (var input in inputs)
            {
                var caves = input.Split("-").Select(i => new Cave(i)).ToArray();
                graph.Add(caves[0], caves[1]);
            }

            return graph.GetAllPaths("start", "end");
        }
    }
}