using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode._2022;

public class PuzzleRunnner
{
    private readonly ITestOutputHelper _testOutput;
    
    public PuzzleRunnner(ITestOutputHelper testOutput)
    {
        _testOutput = testOutput;
    }

    [Fact]
    public void Day01_Calorie_Counting()
    {
        var input = new InputReader().Read("../../../2022/01/input.txt");

        var result1 = new _01.Puzzle1().Resolve(input);
        Assert.Equal(71124, result1);

        var result2 = new _01.Puzzle2().Resolve(input);
        Assert.Equal(204639, result2);
    }
}