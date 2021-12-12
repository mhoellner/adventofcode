using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode._2021._12
{
    [DebuggerDisplay("{DebugToString()}")]
    public class Graph
    {
        private Dictionary<Cave, List<Cave>> Paths { get; } = new Dictionary<Cave, List<Cave>>();

        public void Add(Cave c1, Cave c2)
        {
            if (Paths.ContainsKey(c1))
                Paths[c1].Add(c2);
            else
                Paths.Add(c1, new List<Cave> {c2});
            if (Paths.ContainsKey(c2))
                Paths[c2].Add(c1);
            else
                Paths.Add(c2, new List<Cave> {c1});
        }

        public int GetAllPaths(string start, string end, bool allowSingleSmallTwice = false)
        {
            var startCave = new Cave(start);
            var endCave = new Cave(end);
            var path = new List<Cave>();

            return GetAllPathsRecursive(startCave, endCave, path, allowSingleSmallTwice);
        }

        private int GetAllPathsRecursive(Cave current, Cave end, List<Cave> currentPath, bool allowSingleSmallTwice)
        {
            if (current.Equals(end))
                return 1;
            if (current.IsSmall && currentPath.Contains(current))
                if (!allowSingleSmallTwice || current.Name == "start" || HasDoubleSmallCave(currentPath))
                    return 0;

            currentPath.Add(current);

            return Paths[current].Sum(c => GetAllPathsRecursive(c, end, new List<Cave>(currentPath), allowSingleSmallTwice));
        }

        private static bool HasDoubleSmallCave(List<Cave> currentPath)
        {
            var smallCaves = currentPath.Where(c => c.IsSmall).ToList();

            return smallCaves.Count > smallCaves.Distinct().Count();
        } 

        private string DebugToString()
        {
            return string.Join(" | ", Paths.Select(p => $"{p.Key.Name}: {string.Join(", ", p.Value.Select(v => v.Name))}"));
        }
    }
}