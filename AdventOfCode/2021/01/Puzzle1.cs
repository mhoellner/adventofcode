using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._01
{
    public class Puzzle1 : IPuzzle
    {
        private long currentMax = 0;
        private int counter = 0;
        public long Resolve(List<string> inputs)
        {
            return Resolve(inputs.Select(int.Parse).ToList());
        }

        private long Resolve(List<int> inputs)
        {
            currentMax = inputs[0];
            
            foreach (var input in inputs)
            {
                if (input > currentMax)
                {
                    counter++;
                }

                currentMax = input;
            }

            return counter;
        }
    }
}