using System.Collections.Generic;

namespace AdventOfCode._2020._08
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var manipulatedInputs = GetManipulatedInputs(inputs);

            for (var i = 0; i < manipulatedInputs.Count; i++)
            {
                if (TryResolve(manipulatedInputs[i], out var acc))
                    return acc;
            }

            return 0;
        }

        private List<List<string>> GetManipulatedInputs(List<string> original)
        {
            var manipulatedInputs = new List<List<string>>();

            for (var i = 0; i < original.Count; i++)
            {
                if (original[i].StartsWith("nop"))
                {
                    var manipulated = new List<string>(original);
                    manipulated[i] = manipulated[i].Replace("nop", "jmp");
                    manipulatedInputs.Add(manipulated);
                }
                if (original[i].StartsWith("jmp"))
                {
                    var manipulated = new List<string>(original);
                    manipulated[i] = manipulated[i].Replace("jmp", "nop");
                    manipulatedInputs.Add(manipulated);
                }
            }

            return manipulatedInputs;
        }

        private bool TryResolve(List<string> inputs, out int acc)
        {
            acc = 0;
            var arr = new bool[inputs.Count];

            for (var i = 0; i < inputs.Count; i++)
            {
                if (arr[i])
                    return false;

                arr[i] = true;

                var instruction = inputs[i].Split(' ');
                if (instruction[0] == "acc")
                    acc += int.Parse(instruction[1]);

                if (instruction[0] == "jmp")
                    i += int.Parse(instruction[1]) - 1;
            }

            return true;
        }
    }
}
