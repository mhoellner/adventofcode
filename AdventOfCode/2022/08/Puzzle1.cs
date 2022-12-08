using System.Collections.Generic;

namespace AdventOfCode._2022._08;

public class Puzzle1 : IPuzzle
{
    public long Resolve(List<string> inputs)
    {
        var trees = ForestBuilder.ParseTrees(inputs);

        var counter = 0;
        for (var x = 0; x < trees.Length; x++)
        for (var y = 0; y < trees[x].Length; y++)
            counter += IsVisible(trees, x, y);

        return counter;
    }

    private static int IsVisible(int[][] trees, int x, int y)
    {
        var current = trees[x][y];
        
        for (var leftIndex = 0; leftIndex <= y; leftIndex++)
            if (leftIndex == y)
                return 1;
            else if (trees[x][leftIndex] >= current)
                break;

        for (var rightIndex = trees[x].Length - 1; rightIndex >= y; rightIndex--)
            if (rightIndex == y)
                return 1;
            else if (trees[x][rightIndex] >= current)
                break;

        for (var topIndex = 0; topIndex <= x; topIndex++)
            if (topIndex == x)
                return 1;
            else if (trees[topIndex][y] >= current)
                break;

        for (var bottomIndex = trees.Length - 1; bottomIndex >= x; bottomIndex--)
            if (bottomIndex == x)
                return 1;
            else if (trees[bottomIndex][y] >= current)
                break;

        return 0;
    }
}