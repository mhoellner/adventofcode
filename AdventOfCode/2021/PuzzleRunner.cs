using System.Collections.Generic;
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
        public void Day01_SonarSweep()
        {
            var input = new InputReader().Read("../../../2021/01/input.txt");

            var result1 = new _01.Puzzle1().Resolve(input);
            Assert.Equal(1527, result1);

            var result2 = new _01.Puzzle2().Resolve(input);
            Assert.Equal(1575, result2);
        }

        [Fact]
        public void Day02_Dive()
        {
            var input = new InputReader().Read("../../../2021/02/input.txt");

            var result1 = new _02.Puzzle1().Resolve(input);
            Assert.Equal(1660158, result1);

            var result2 = new _02.Puzzle2().Resolve(input);
            Assert.Equal(1604592846, result2);
        }

        [Fact]
        public void Day03_BinaryDiagnostic()
        {
            var input = new InputReader().Read("../../../2021/03/input.txt");

            var result1 = new _03.Puzzle1().Resolve(input);
            Assert.Equal(4174964, result1);

            var result2 = new _03.Puzzle2().Resolve(input);
            Assert.Equal(4474944, result2);
        }

        [Fact]
        public void Day04_GiantSquid()
        {
            var input = new InputReader().Read("../../../2021/04/input.txt");

            var result1 = new _04.Puzzle1().Resolve(input);
            Assert.Equal(58412, result1);

            var result2 = new _04.Puzzle2().Resolve(input);
            Assert.Equal(10030, result2);
        }

        [Fact]
        public void Day05_HydrothermalVenture()
        {
            var input = new InputReader().Read("../../../2021/05/input.txt");

            var result1 = new _05.Puzzle1().Resolve(input);
            Assert.Equal(6007, result1);

            var result2 = new _05.Puzzle2().Resolve(input);
            Assert.Equal(19349, result2);
        }

        [Fact]
        public void Day06_Lanternfish()
        {
            var input = new InputReader().Read("../../../2021/06/input.txt");

            var result1 = new _06.Puzzle(80).Resolve(input);
            Assert.Equal(351092, result1);

            var result2 = new _06.Puzzle(256).Resolve(input);
            Assert.Equal(1595330616005, result2);
        }

        [Fact]
        public void Day07_TheTreacheryOfWhales()
        {
            var input = new InputReader().Read("../../../2021/07/input.txt");

            var result1 = new _07.Puzzle1().Resolve(input);
            Assert.Equal(355989, result1);

            var result2 = new _07.Puzzle2().Resolve(input);
            Assert.Equal(102245489, result2);
        }

        [Fact]
        public void Day08_SevenSegmentSearch()
        {
            var input = new InputReader().Read("../../../2021/08/input.txt");

            var result1 = new _08.Puzzle1().Resolve(input);
            Assert.Equal(456, result1);

            var result2 = new _08.Puzzle2().Resolve(input);
            Assert.Equal(1091609, result2);
        }

        [Fact]
        public void Day09_SmokeBasin()
        {
            var input = new InputReader().Read("../../../2021/09/input.txt");

            var result1 = new _09.Puzzle1().Resolve(input);
            Assert.Equal(548, result1);

            var result2 = new _09.Puzzle2().Resolve(input);
            Assert.Equal(786048, result2);
        }

        [Fact]
        public void Day10_SyntaxScoring()
        {
            var input = new InputReader().Read("../../../2021/10/input.txt");

            var result1 = new _10.Puzzle1().Resolve(input);
            Assert.Equal(462693, result1);

            var result2 = new _10.Puzzle2().Resolve(input);
            Assert.Equal(3094671161, result2);
        }

        [Fact]
        public void Day11_DumboOctopus()
        {
            var input = new InputReader().Read("../../../2021/11/input.txt");

            var result1 = new _11.Puzzle1().Resolve(input);
            Assert.Equal(1729, result1);

            var result2 = new _11.Puzzle2().Resolve(input);
            Assert.Equal(237, result2);
        }

        [Fact]
        public void Day12_PassagePathing()
        {
            var input = new InputReader().Read("../../../2021/12/input.txt");

            var result1 = new _12.Puzzle1().Resolve(input);
            Assert.Equal(4167, result1);

            var result2 = new _12.Puzzle2().Resolve(input);
            Assert.Equal(98441, result2);
        }

        [Fact]
        public void Day13_TransparentOrigami()
        {
            var input = new InputReader().Read("../../../2021/13/input.txt");

            var result1 = new _13.Puzzle1().Resolve(input);
            Assert.Equal(684, result1);

            new _13.Puzzle2(_outputHelper).Resolve(input);
        }

        [Fact]
        public void Day14_ExtendedPolymerization()
        {
            var input = new InputReader().Read("../../../2021/14/input.txt");

            var result1 = new _14.Puzzle(10).Resolve(input);
            Assert.Equal(3406, result1);

            var result2 = new _14.Puzzle(40).Resolve(input);
            Assert.Equal(3941782230241, result2);
        }

        [Fact]
        public void Day15_Chiton()
        {
            var input = new InputReader().Read("../../../2021/15/input.txt");

            var result1 = new _15.Puzzle().Resolve(input);
            Assert.Equal(696, result1);
            
            var result2 = new _15.Puzzle(5).Resolve(input);
            Assert.Equal(2952, result2);
        }

        [Fact]
        public void Day16_PacketDecoder()
        {
            var input = new InputReader().Read("../../../2021/16/input.txt");

            var result1 = new _16.Puzzle1().Resolve(input);
            Assert.Equal(953, result1);
            
            var result2 = new _16.Puzzle2().Resolve(input);
            Assert.Equal(246225449979, result2);
        }

        [Fact]
        public void Day17_TrickShot()
        {
            var input = new InputReader().Read("../../../2021/17/input.txt");

            var result1 = new _17.Puzzle1().Resolve(input);
            Assert.Equal(8256, result1);

            var result2 = new _17.Puzzle2().Resolve(input);
            Assert.Equal(2326, result2);
        }

        [Fact]
        public void Day18_Snailfish()
        {
            var input = new InputReader().Read("../../../2021/18/input.txt");

            Assert.Equal(4323, new _18.Puzzle1().Resolve(input));

            Assert.Equal(4749, new _18.Puzzle2().Resolve(input));
        }

        [Fact]
        public void Day20_TrenchMap()
        {
            var input = new InputReader().Read("../../../2021/20/input.txt");
            
            Assert.Equal(5619, new _20.Puzzle().Resolve(input));
            
            Assert.Equal(20122, new _20.Puzzle(50).Resolve(input));
        }

        [Fact]
        public void Day21_DiracDice()
        {
            var input = new InputReader().Read("../../../2021/21/input.txt");
            
            Assert.Equal(989352, new _21.Puzzle1().Resolve(input));
            
            Assert.Equal(430229563871565, new _21.Puzzle2().Resolve(input));
        }

        [Fact]
        public void Day22_ReactorReboot()
        {
            var input = new InputReader().Read("../../../2021/22/input.txt");
            
            Assert.Equal(610196, new _22.Puzzle().Resolve(input));
            
            Assert.Equal(1282401587270826, new _22.Puzzle(false).Resolve(input));
        }
    }
}