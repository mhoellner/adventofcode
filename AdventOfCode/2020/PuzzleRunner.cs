using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode._2020
{
    public class PuzzleRunner
    {
        private readonly ITestOutputHelper _output;
        public PuzzleRunner(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Day01()
        {
            var input = new InputReader().Read("../../../2020/01/input.txt");

            var result1 = new _01.Puzzle1().Resolve(input);
            Assert.Equal(786811, result1);

            var result2 = new _01.Puzzle2().Resolve(input);
            Assert.Equal(199068980, result2);
        }

        [Fact]
        public void Day02()
        {
            var input = new InputReader().Read("../../../2020/02/input.txt");
            var result1 = new _02.Puzzle1().Resolve(input);
            Assert.Equal(493, result1);
            var result2 = new _02.Puzzle2().Resolve(input);
            Assert.Equal(593, result2);
        }

        [Fact]
        public void Day03()
        {
            var input = new InputReader().Read("../../../2020/03/input.txt");
            var result1 = new _03.Puzzle1().Resolve(input);
            Assert.Equal(284, result1);
            var result2 = new _03.Puzzle2().Resolve(input);
            Assert.Equal(3510149120, result2);
        }

        [Fact]
        public void Day04()
        {
            var input = new InputReader().Read("../../../2020/04/input.txt");
            var result1 = new _04.Puzzle1().Resolve(input);
            Assert.Equal(200, result1);
            var result2 = new _04.Puzzle2().Resolve(input);
            Assert.Equal(116, result2);
        }

        [Fact]
        public void Day05()
        {
            var input = new InputReader().Read("../../../2020/05/input.txt");
            var result1 = new _05.Puzzle1().Resolve(input);
            Assert.Equal(965, result1);
            var result2 = new _05.Puzzle2().Resolve(input);
            Assert.Equal(524, result2);
        }

        [Fact]
        public void Day06()
        {
            var input = new InputReader().Read("../../../2020/06/input.txt");
            var result1 = new _06.Puzzle1().Resolve(input);
            Assert.Equal(6947, result1);
            var result2 = new _06.Puzzle2().Resolve(input);
            Assert.Equal(3398, result2);
        }

        [Fact]
        public void Day07()
        {
            var input = new InputReader().Read("../../../2020/07/input.txt");
            var result1 = new _07.Puzzle1().Resolve(input);
            Assert.Equal(287, result1);
            var result2 = new _07.Puzzle2().Resolve(input);
            Assert.Equal(48160, result2);
        }

        [Fact]
        public void Day08()
        {
            var input = new InputReader().Read("../../../2020/08/input.txt");
            var result1 = new _08.Puzzle1().Resolve(input);
            Assert.Equal(1766, result1);
            var result2 = new _08.Puzzle2().Resolve(input);
            Assert.Equal(1639, result2);
        }

        [Fact]
        public void Day09()
        {
            var input = new InputReader().Read("../../../2020/09/input.txt");
            var result1 = new _09.Puzzle1().Resolve(input);
            Assert.Equal(50047984, result1);
            var result2 = new _09.Puzzle2().Resolve(input);
            Assert.Equal(5407707, result2);
        }

        [Fact]
        public void Day10()
        {
            var input = new InputReader().Read("../../../2020/10/input.txt");
            var result1 = new _10.Puzzle1().Resolve(input);
            Assert.Equal(2380, result1);
            var result2 = new _10.Puzzle2().Resolve(input);
            Assert.Equal(48358655787008, result2);
        }

        [Fact]
        public void Day11()
        {
            var input = new InputReader().Read("../../../2020/11/input.txt");
            var result1 = new _11.Puzzle1().Resolve(input);
            Assert.Equal(2183, result1);
        }

        [Fact]
        public void Day12()
        {
            var input = new InputReader().Read("../../../2020/12/input.txt");
            var result1 = new _12.Puzzle1().Resolve(input);
            Assert.Equal(1631, result1);
            var result2 = new _12.Puzzle2().Resolve(input);
            Assert.Equal(58606, result2);
        }

        [Fact]
        public void Day13()
        {
            var input = new InputReader().Read("../../../2020/13/input.txt");
            var result1 = new _13.Puzzle1().Resolve(input);
            Assert.Equal(370, result1);
            var result2 = new _13.Puzzle2().Resolve(input);
            _output.WriteLine(result2.ToString());
            Assert.Equal(894954360381385, result2);
        }

        [Fact]
        public void Day13_Examples()
        {
            var puzzle2 = new _13.Puzzle2 { Start = 0 };
            var input = new List<string> { "", "17,x,13,19" };
            Assert.Equal(3417, puzzle2.Resolve(input));
            input = new List<string> { "", "67,7,59,61" };
            Assert.Equal(754018, puzzle2.Resolve(input));
            input = new List<string> { "", "67,x,7,59,61" };
            Assert.Equal(779210, puzzle2.Resolve(input));
            input = new List<string> { "", "67,7,x,59,61" };
            Assert.Equal(1261476, puzzle2.Resolve(input));
            input = new List<string> { "", "1789,37,47,1889" };
            Assert.Equal(1202161486, puzzle2.Resolve(input));
        }

        [Fact]
        public void Day14()
        {
            var input = new InputReader().Read("../../../2020/14/input.txt");
            var result1 = new _14.Puzzle1().Resolve(input);
            Assert.Equal(8332632930672, result1);
            var result2 = new _14.Puzzle2().Resolve(input);
            Assert.Equal(4753238784664, result2);
        }

        [Fact]
        public void Day15()
        {
            var input = new InputReader().Read("../../../2020/15/input.txt");
            var result1 = new _15.Puzzle().Resolve(input);
            Assert.Equal(387, result1);
            var result2 = new _15.Puzzle { Target = 30_000_000 }.Resolve(input);
            Assert.Equal(6428, result2);
        }

        [Fact]
        public void Day16()
        {
            var input = new InputReader().Read("../../../2020/16/input.txt");
            var result1 = new _16.Puzzle1().Resolve(input);
            Assert.Equal(30869, result1);
            var result2 = new _16.Puzzle2().Resolve(input);
            Assert.Equal(4381476149273, result2);
        }

        [Fact]
        public void Day18()
        {
            var input = new InputReader().Read("../../../2020/18/input.txt");
            var result1 = new _18.Puzzle1().Resolve(input);
            Assert.Equal(50956598240016, result1);
            new _18.Puzzle2().Resolve(input);
            // is wrong for some reason
        }

        [Fact]
        public void Day18_Tests()
        {
            var input = new List<string> { "1 + (2 * 3) + (4 * (5 + 6))", "2 * 3 + (4 * 5)", "5 + (8 * 3 + 9 + 3 * 4 * 3)", "5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2" };
            var result2 = new _18.Puzzle2().Resolve(input);
            Assert.Equal(51 + 46 + 1445 + 669060 + 23340, result2);
        }
    }
}
