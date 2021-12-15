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

        [Fact]
        public void Day09()
        {
            var input = new InputReader().Read("../../../2021/09/input.txt");

            var result1 = new _09.Puzzle1().Resolve(input);
            Assert.Equal(548, result1);

            var result2 = new _09.Puzzle2().Resolve(input);
            Assert.Equal(786048, result2);
        }

        [Fact]
        public void Day10()
        {
            var input = new InputReader().Read("../../../2021/10/input.txt");

            var result1 = new _10.Puzzle1().Resolve(input);
            Assert.Equal(462693, result1);

            var result2 = new _10.Puzzle2().Resolve(input);
            Assert.Equal(3094671161, result2);
        }

        [Fact]
        public void Day11()
        {
            var input = new InputReader().Read("../../../2021/11/input.txt");

            var result1 = new _11.Puzzle1().Resolve(input);
            Assert.Equal(1729, result1);

            var result2 = new _11.Puzzle2().Resolve(input);
            Assert.Equal(237, result2);
        }

        [Fact]
        public void Day12()
        {
            var input = new InputReader().Read("../../../2021/12/input.txt");

            var result1 = new _12.Puzzle1().Resolve(input);
            Assert.Equal(4167, result1);

            var result2 = new _12.Puzzle2().Resolve(input);
            Assert.Equal(98441, result2);
        }

        [Fact]
        public void Day13()
        {
            var input = new InputReader().Read("../../../2021/13/input.txt");

            var result1 = new _13.Puzzle1().Resolve(input);
            Assert.Equal(684, result1);

            new _13.Puzzle2(_outputHelper).Resolve(input);
        }

        [Fact]
        public void Day14()
        {
            var input = new InputReader().Read("../../../2021/14/input.txt");

            var result1 = new _14.Puzzle(10).Resolve(input);
            Assert.Equal(3406, result1);

            var result2 = new _14.Puzzle(40).Resolve(input);
            Assert.Equal(3941782230241, result2);
        }

        [Fact]
        public void Day15()
        {
            var input = new InputReader().Read("../../../2021/15/input.txt");

            var result1 = new _15.Puzzle().Resolve(input);
            Assert.Equal(696, result1);
            
            var result2 = new _15.Puzzle(5).Resolve(input);
            Assert.Equal(2952, result2);
        }
    }
}