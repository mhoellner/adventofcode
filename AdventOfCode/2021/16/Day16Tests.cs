using System.Collections.Generic;
using Xunit;

namespace AdventOfCode._2021._16
{
    public class Day16Tests
    {
        [Fact]
        public void Part1()
        {
            var puzzle1 = new Puzzle1();
            Assert.Equal(16, puzzle1.Resolve(new List<string> {"8A004A801A8002F478"}));
            Assert.Equal(12, puzzle1.Resolve(new List<string> {"620080001611562C8802118E34"}));
            Assert.Equal(23, puzzle1.Resolve(new List<string> {"C0015000016115A2E0802F182340"}));
            Assert.Equal(31, puzzle1.Resolve(new List<string> {"A0016C880162017C3686B18A3D4780"}));
        }

        [Fact]
        public void Part2()
        {
            var puzzle2 = new Puzzle2();
            Assert.Equal(3, puzzle2.Resolve(new List<string> {"C200B40A82"}));
            Assert.Equal(54, puzzle2.Resolve(new List<string> {"04005AC33890"}));
            Assert.Equal(7, puzzle2.Resolve(new List<string> {"880086C3E88112"}));
            Assert.Equal(9, puzzle2.Resolve(new List<string> {"CE00C43D881120"}));
            Assert.Equal(1, puzzle2.Resolve(new List<string> {"D8005AC2A8F0"}));
            Assert.Equal(0, puzzle2.Resolve(new List<string> {"F600BC2D8F"}));
            Assert.Equal(0, puzzle2.Resolve(new List<string> {"9C005AC2F8F0"}));
            Assert.Equal(1, puzzle2.Resolve(new List<string> {"9C0141080250320F1802104A08"}));
        }
    }
}