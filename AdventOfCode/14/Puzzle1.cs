using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._14
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var memory = new Dictionary<int, long>();
            var mask = string.Empty;
            foreach (var input in inputs)
            {
                var command = input.Split(" = ");
                if (command[0] == "mask")
                {
                    mask = command[1];
                    continue;
                }

                var index = int.Parse(command[0].Substring(4, command[0].Length - 5));
                var value = long.Parse(command[1]);

                memory[index] = MaskValue(mask, value);
            }

            return memory.Values.Sum();
        }

        private long MaskValue(string mask, long value)
        {
            var binary = Convert.ToString(value, 2).PadLeft(36, '0').ToCharArray();
            for (var i = 0; i < mask.Length; i++)
            {
                if (mask[i] == '0' || mask[i] == '1')
                    binary[i] = mask[i];
            }

            return Convert.ToInt64(new string(binary), 2);
        }
    }
}
