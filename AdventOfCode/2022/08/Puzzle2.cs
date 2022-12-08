using System.Collections.Generic;

namespace AdventOfCode._2022._08;

public class Puzzle2 : IPuzzle
{
    public long Resolve(List<string> inputs)
    {
        var trees = ForestBuilder.ParseTrees(inputs);

        var maxScenicScore = 0;
        for (var x = 1; x < trees.Length - 1; x++)
        for (var y = 1; y < trees[x].Length - 1; y++)
        {
            var scenicScore = CalculateScenicScore(trees, x, y);
            if (scenicScore > maxScenicScore)
                maxScenicScore = scenicScore;
        }

        return maxScenicScore;
    }

    private static int CalculateScenicScore(int[][] trees, int x, int y)
    {
        var current = trees[x][y];

        var leftScore = 1;
        for (var leftIndex = y - 1; leftIndex > 0; leftIndex--)
            if (trees[x][leftIndex] >= current)
                break;
            else
                leftScore++;

        var rightScore = 1;
        for (var rightIndex = y + 1; rightIndex < trees[x].Length - 1; rightIndex++)
            if (trees[x][rightIndex] >= current)
                break;
            else
                rightScore++;

        var topScore = 1;
        for (var topIndex = x - 1; topIndex > 0; topIndex--)
            if (trees[topIndex][y] >= current)
                break;
            else
                topScore++;

        var bottomScore = 1;
        for (var bottomIndex = x + 1; bottomIndex < trees.Length - 1; bottomIndex++)
            if (trees[bottomIndex][y] >= current)
                break;
            else
                bottomScore++;

        return leftScore * rightScore * topScore * bottomScore;
    }
}