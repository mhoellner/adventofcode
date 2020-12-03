using System.Collections.Generic;

namespace AdventOfCode._03
{
    public static class Extensions
    {
        public static long CountTrees(this List<string> inputs, int rightStepSize, int downStepSize)
        {
            var amount = 0;
            var rightStep = 0;
            for (var i = 0; i < inputs.Count;)
            {
                var input = inputs[i];
                if (input[rightStep % input.Length] == '#')
                    amount++;

                rightStep += rightStepSize;
                i += downStepSize;
            }

            return amount;
        }
    }
}
