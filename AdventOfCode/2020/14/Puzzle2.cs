using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020._14
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var memory = new Dictionary<long, long>();
            var mask = string.Empty;

            foreach (var input in inputs)
            {
                var command = input.Split(" = ");
                if (command[0] == "mask")
                {
                    mask = command[1];
                    continue;
                }

                var index = long.Parse(command[0].Substring(4, command[0].Length - 5));
                var indices = GetPossibleIndices(mask, index);
                var value = long.Parse(command[1]);

                foreach (var possibleIndex in indices)
                {
                    memory[possibleIndex] = value;
                }
            }

            return memory.Values.Sum();
        }

        private long[] GetPossibleIndices(string mask, long index)
        {
            var binary = GetMaskedIndex(mask, Convert.ToString(index, 2).PadLeft(36, '0').ToCharArray());
            var list = new long[(int) Math.Pow(2, mask.Count(c => c == 'X'))];
            for (var i = 0; i < list.Length; i++)
            {
                var floatingBits = Convert.ToString(i, 2).PadLeft(mask.Count(c => c == 'X'), '0');
                list[i] = ApplyFloatingBits(binary, floatingBits);
            }

            return list;
        }

        private char[] GetMaskedIndex(string mask, char[] binary)
        {
            for (var i = 0; i < mask.Length; i++)
            {
                if (mask[i] == '1' || mask[i] == 'X')
                    binary[i] = mask[i];
            }

            return binary;
        }

        private long ApplyFloatingBits(char[] binary, string floatingBits)
        {
            binary = (char[]) binary.Clone();
            var previousIndex = 0;
            var temp = new string(binary);
            foreach (var bit in floatingBits)
            {
                var replaceIndex = temp.IndexOf('X', previousIndex);
                previousIndex = replaceIndex + 1;
                binary[replaceIndex] = bit;
            }

            return Convert.ToInt64(new string(binary), 2);
        }
    }
}
