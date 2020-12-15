using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._15
{
    public class Puzzle : IPuzzle
    {
        public int Target { get; set; } = 2020;

        public long Resolve(List<string> inputs)
        {
            var numbers = inputs[0].Split(',').Select(int.Parse).ToList();
            var memory = new Dictionary<int, int>();
            for (var i = 0; i < numbers.Count - 1; i++)
                memory[numbers[i]] = i + 1;
            var previous = numbers[numbers.Count - 1];
            for (var i = numbers.Count + 1; i <= Target; i++)
            {
                if (memory.ContainsKey(previous))
                {
                    var next = i - memory[previous] - 1;
                    memory[previous] = i - 1;
                    previous = next;
                }
                else
                {
                    memory[previous] = i - 1;
                    previous = 0;
                }
            }

            return previous;
        }
    }
}
