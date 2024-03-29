using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode._2022;

public class PuzzleRunner
{
    private readonly ITestOutputHelper _testOutput;
    
    public PuzzleRunner(ITestOutputHelper testOutput)
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

    [Fact]
    public void Day05_Supply_Stacks()
    {
        var input = InputReader.Read("../../../2022/05/input.txt");

        var result1 = new _05.Puzzle1().Resolve(input);
        Assert.Equal("MQSHJMWNH", result1);

        var result2 = new _05.Puzzle2().Resolve(input);
        Assert.Equal("LLWJRBHVZ", result2);
    }

    [Fact]
    public void Day06_Tuning_Trouble()
    {
        var input = InputReader.Read("../../../2022/06/input.txt");

        var result1 = new _06.Puzzle().Resolve(input);
        Assert.Equal(1848, result1);

        var result2 = new _06.Puzzle(14).Resolve(input);
        Assert.Equal(2308, result2);
    }

    [Fact]
    public void Day07_No_Space_Left_On_Device()
    {
        var input = InputReader.Read("../../../2022/07/input.txt");

        var result1 = new _07.Puzzle1().Resolve(input);
        Assert.Equal(1348005, result1);

        var result2 = new _07.Puzzle2().Resolve(input);
        Assert.Equal(12785886, result2);
    }

    [Fact]
    public void Day08_Treetop_Tree_Houses()
    {
        var input = InputReader.Read("../../../2022/08/input.txt");

        var result1 = new _08.Puzzle1().Resolve(input);
        Assert.Equal(1717, result1);

        var result2 = new _08.Puzzle2().Resolve(input);
        Assert.Equal(321975, result2);
    }

    [Fact]
    public void Day09_Rope_Bridge()
    {
        var input = InputReader.Read("../../../2022/09/input.txt");

        var result1 = new _09.Puzzle1().Resolve(input);
        Assert.Equal(6391, result1);
    }

    [Fact]
    public void Day10_CathodeRay_Tube()
    {
        var input = InputReader.Read("../../../2022/10/input.txt");

        var result1 = new _10.Puzzle1().Resolve(input);
        Assert.Equal(12520, result1);

        var result2 = new _10.Puzzle2().Resolve(input);
        _testOutput.WriteLine(result2);
        Assert.Equal("""
        ####.#..#.###..####.###....##..##..#....
        #....#..#.#..#....#.#..#....#.#..#.#....
        ###..####.#..#...#..#..#....#.#....#....
        #....#..#.###...#...###.....#.#.##.#....
        #....#..#.#....#....#....#..#.#..#.#....
        ####.#..#.#....####.#.....##...###.####.

        """, result2);
    }

    [Fact]
    public void Day11_Monkey_in_the_Middle()
    {
        var input = InputReader.Read("../../../2022/11/input.txt");

        var result1 = new _11.Puzzle().Resolve(input);
        Assert.Equal(111210, result1);

        var result2 = new _11.Puzzle(10_000, isPartTwo: true).Resolve(input);
        Assert.Equal(15447387620, result2);
    }
}