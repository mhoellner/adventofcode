namespace AdventOfCode2023;

public class TestRunner
{
    [Fact]
    public void Day01_Trebuchet()
    {
        var input = DataProvider.FromFile("../../../Day01/input.txt");

        var puzzle = new Day01.Puzzle();
        var result1 = puzzle.ResolvePart1(input);
        Assert.Equal(55108, result1);

        var result2 = puzzle.ResolvePart2(input);
        Assert.Equal(56324, result2);
    }

    [Fact]
    public void Day04_Scratchcards()
    {
        var input = DataProvider.FromFile("../../../Day04/input.txt");

        var puzzle = new Day04.Puzzle();
        var result1 = puzzle.ResolvePart1(input);
        Assert.Equal(24175, result1);

        var result2 = puzzle.ResolvePart2(input);
        Assert.Equal(18846301, result2);
    }
}