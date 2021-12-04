using System;
using System.Linq;

namespace AdventOfCode._2020._16
{
    public class Rule
    {
        public string Name { get; }
        private readonly int _one, _two, _three, _four;
        public Rule(string name, int one, int two, int three, int four) => (Name, _one, _two, _three, _four) = (name, one, two, three, four);
        public bool Matches(int value) => (value >= _one && value <= _two) || (value >= _three && value <= _four);
        public static Rule FromInput(string input)
        {
            var values = input.Split(": ")[1].Split(new string[] { " or ", "-" }, StringSplitOptions.None).Select(int.Parse).ToArray();
            return new Rule(input.Split(": ")[0], values[0], values[1], values[2], values[3]);
        }
    }
}
