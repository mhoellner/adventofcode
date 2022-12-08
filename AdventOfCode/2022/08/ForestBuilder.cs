using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2022._08;

public static class ForestBuilder
{
    public static int[][] ParseTrees(List<string> inputs)
    {
        var trees = new int[inputs.Count][];
        for (var index = 0; index < inputs.Count; index++)
        {
            trees[index] = inputs[index].Select(c => int.Parse((string) c.ToString())).ToArray();
        }

        return trees;
    }
}