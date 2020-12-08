using System.Collections.Generic;

namespace AdventOfCode._08
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var acc = 0;
            var arr = new bool[inputs.Count];

            for (var i = 0; i < inputs.Count; i++)
            {
                if (arr[i])
                    return acc;

                arr[i] = true;
                
                var instruction = inputs[i].Split(' ');
                if (instruction[0] == "acc")
                    acc += int.Parse(instruction[1]);

                if (instruction[0] == "jmp")
                    i += int.Parse(instruction[1]) - 1;
            }

            return acc;
        }
    }
}
