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
        var input = InputReader.Read("../../../2022/01/input.txt");

        var result1 = new _01.Puzzle1().Resolve(input);
        Assert.Equal(71124, result1);

        var result2 = new _01.Puzzle2().Resolve(input);
        Assert.Equal(204639, result2);
    }

    [Fact]
    public void Day02_Rock_Paper_Scissors()
    {
        var input = InputReader.Read("../../../2022/02/input.txt");

        var result1 = new _02.Puzzle1().Resolve(input);
        Assert.Equal(11873, result1);

        var result2 = new _02.Puzzle2().Resolve(input);
        Assert.Equal(12014, result2);
    }

    [Fact]
    public void Day03_Rucksack_Reorganization()
    {
        var input = InputReader.Read("../../../2022/03/input.txt");

        var result1 = new _03.Puzzle1().Resolve(input);
        Assert.Equal(7727, result1);

        var result2 = new _03.Puzzle2().Resolve(input);
        Assert.Equal(2609, result2);
    }

    [Fact]
    public void Day04_Camp_Cleanup()
    {
        var input = InputReader.Read("../../../2022/04/input.txt");

        var result1 = new _04.Puzzle1().Resolve(input);
        Assert.Equal(444, result1);

        var result2 = new _04.Puzzle2().Resolve(input);
        Assert.Equal(801, result2);
    }
}