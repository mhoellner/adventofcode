using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode._2021._18
{
    public class SnailfishNumberTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public SnailfishNumberTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Theory]
        [InlineData("[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]")]
        public void Parse(string number)
        {
            Assert.Equal(number, SnailfishNumber.Parse(number).ToString());
        }

        [Theory]
        [InlineData("[[1,2],[[3,4],5]]", 143)]
        [InlineData("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", 1384)]
        [InlineData("[[[[1,1],[2,2]],[3,3]],[4,4]]", 445)]
        [InlineData("[[[[3,0],[5,3]],[4,4]],[5,5]]", 791)]
        [InlineData("[[[[5,0],[7,4]],[5,5]],[6,6]]", 1137)]
        [InlineData("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", 3488)]
        public void CalculateMagnitude(string number, int expected)
        {
            Assert.Equal(expected, SnailfishNumber.Parse(number).CalculateMagnitude());
        }

        [Theory]
        [MemberData(nameof(AddTestData))]
        public void Add(string[] numbers, string expected)
        {
            Assert.Equal(expected, numbers.Select(SnailfishNumber.Parse).Aggregate((SnailfishNumber) null,
                (number, snailfishNumber) => SnailfishNumber.Add(number, snailfishNumber, _outputHelper)).ToString());
        }

        [Fact]
        public void Part2()
        {
            var numbers = new[]
            {
                "[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]",
                "[[[5,[2,8]],4],[5,[[9,9],0]]]",
                "[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]",
                "[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]",
                "[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]",
                "[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]",
                "[[[[5,4],[7,7]],8],[[8,3],8]]",
                "[[9,3],[[9,9],[6,[4,9]]]]",
                "[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]",
                "[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]"
            }.ToList();
            
            Assert.Equal(3993, new Puzzle2().Resolve(numbers));
        }

        public static object[][] AddTestData => new[]
        {
            new object[]
            {
                new[] {"[[[[4,3],4],4],[7,[[8,4],9]]]", "[1,1]"},
                "[[[[0,7],4],[[7,8],[6,0]]],[8,1]]"
            },
            new object[]
            {
                new[] {"[1,1]", "[2,2]", "[3,3]", "[4,4]"},
                "[[[[1,1],[2,2]],[3,3]],[4,4]]"
            },
            new object[]
            {
                new[] {"[1,1]", "[2,2]", "[3,3]", "[4,4]", "[5,5]"},
                "[[[[3,0],[5,3]],[4,4]],[5,5]]"
            },
            new object[]
            {
                new[] {"[1,1]", "[2,2]", "[3,3]", "[4,4]", "[5,5]", "[6,6]"},
                "[[[[5,0],[7,4]],[5,5]],[6,6]]"
            },
            new object[]
            {
                new[] {"[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]", "[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]", "[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]", "[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]", "[7,[5,[[3,8],[1,4]]]]", "[[2,[2,2]],[8,[8,1]]]", "[2,9]", "[1,[[[9,3],9],[[9,0],[0,7]]]]", "[[[5,[7,4]],7],1]", "[[[[4,2],2],6],[8,7]]"},
                "[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]"
            },
            new object[]
            {
                new[] {"[[[[[9,8],1],2],3],4]"},
                "[[[[0,9],2],3],4]"
            },
            new object[]
            {
                new[] {"[7,[6,[5,[4,[3,2]]]]]"},
                "[7,[6,[5,[7,0]]]]"
            },
            new object[]
            {
                new[] {"[[6,[5,[4,[3,2]]]],1]"},
                "[[6,[5,[7,0]]],3]"
            },
            new object[]
            {
                new[] {"[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]"},
                "[[3,[2,[8,0]]],[9,[5,[7,0]]]]"
            },
            new object[]
            {
                new[] {"[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]"},
                "[[3,[2,[8,0]]],[9,[5,[7,0]]]]"
            },
        };
    }
}