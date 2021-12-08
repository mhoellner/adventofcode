using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode._2021
{
    public class PuzzleRunner
    {
        private readonly ITestOutputHelper _outputHelper;

        public PuzzleRunner(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Day01()
        {
            var input = new InputReader().Read("../../../2021/01/input.txt");

            var result1 = new _01.Puzzle1().Resolve(input);
            Assert.Equal(1527, result1);

            var result2 = new _01.Puzzle2().Resolve(input);
            Assert.Equal(1575, result2);
        }

        [Fact]
        public void Day02()
        {
            var input = new InputReader().Read("../../../2021/02/input.txt");

            var result1 = new _02.Puzzle1().Resolve(input);
            Assert.Equal(1660158, result1);

            var result2 = new _02.Puzzle2().Resolve(input);
            Assert.Equal(1604592846, result2);
        }

        [Fact]
        public void Day03()
        {
            var input = new InputReader().Read("../../../2021/03/input.txt");

            var result1 = new _03.Puzzle1().Resolve(input);
            Assert.Equal(4174964, result1);

            var result2 = new _03.Puzzle2().Resolve(input);
            Assert.Equal(4474944, result2);
        }

        [Fact]
        public void Day04()
        {
            var input = new InputReader().Read("../../../2021/04/input.txt");

            var result1 = new _04.Puzzle1().Resolve(input);
            Assert.Equal(58412, result1);

            var result2 = new _04.Puzzle2().Resolve(input);
            Assert.Equal(10030, result2);
        }

        [Fact]
        public void Day05()
        {
            var input = new InputReader().Read("../../../2021/05/input.txt");

            var result1 = new _05.Puzzle1().Resolve(input);
            Assert.Equal(6007, result1);

            var result2 = new _05.Puzzle2().Resolve(input);
            Assert.Equal(19349, result2);
        }

        [Fact]
        public void Day06()
        {
            var input = new InputReader().Read("../../../2021/06/input.txt");

            var result1 = new _06.Puzzle(80).Resolve(input);
            Assert.Equal(351092, result1);

            var result2 = new _06.Puzzle(256).Resolve(input);
            Assert.Equal(1595330616005, result2);
        }

        [Fact]
        public void Day07()
        {
            var input = new InputReader().Read("../../../2021/07/input.txt");

            var result1 = new _07.Puzzle1().Resolve(input);
            Assert.Equal(355989, result1);

            var result2 = new _07.Puzzle2().Resolve(input);
            Assert.Equal(102245489, result2);
        }

        [Fact]
        public void Day08()
        {
            var input = new InputReader().Read("../../../2021/08/input.txt");

            var result1 = new _08.Puzzle1().Resolve(input);
            Assert.Equal(456, result1);

            var result2 = new _08.Puzzle2().Resolve(input);
            Assert.Equal(1091609, result2);
        }
    }
}