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
    public void Day01()
    {
        var input = new InputReader().Read("../../../2022/01/input.txt");

        var result1 = new _01.Puzzle1().Resolve(input);
    }
}