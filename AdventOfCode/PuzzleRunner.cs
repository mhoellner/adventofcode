﻿using Xunit;

namespace AdventOfCode
{
    public class PuzzleRunner
    {
        [Fact]
        public void Day01()
        {
            var input = new InputReader().Read("../../../01/input.txt");

            var result1 = new _01.Puzzle1().Resolve(input);
            Assert.Equal(786811, result1);

            var result2 = new _01.Puzzle2().Resolve(input);
            Assert.Equal(199068980, result2);
        }

        [Fact]
        public void Day02()
        {
            var input = new InputReader().Read("../../../02/input.txt");
            var result1 = new _02.Puzzle1().Resolve(input);
            Assert.Equal(493, result1);
            var result2 = new _02.Puzzle2().Resolve(input);
            Assert.Equal(593, result2);
        }

        [Fact]
        public void Day03()
        {
            var input = new InputReader().Read("../../../03/input.txt");
            var result1 = new _03.Puzzle1().Resolve(input);
            Assert.Equal(284, result1);
            var result2 = new _03.Puzzle2().Resolve(input);
            Assert.Equal(3510149120, result2);
        }

        [Fact]
        public void Day04()
        {
            var input = new InputReader().Read("../../../04/input.txt");
            var result1 = new _04.Puzzle1().Resolve(input);
            Assert.Equal(200, result1);
            var result2 = new _04.Puzzle2().Resolve(input);
            Assert.Equal(116, result2);
        }

        [Fact]
        public void Day05()
        {
            var input = new InputReader().Read("../../../05/input.txt");
            var result1 = new _05.Puzzle1().Resolve(input);
            Assert.Equal(965, result1);
            var result2 = new _05.Puzzle2().Resolve(input);
            Assert.Equal(524, result2);
        }
    }
}
