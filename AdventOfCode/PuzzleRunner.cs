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
            var result2 = new _02.Puzzle2().Resolve(input);
        }
    }
}
