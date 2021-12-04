using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020._02
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var correctPasswords = 0;

            foreach (var input in inputs)
            {
                var split = input.Split(' ', '-');

                var min = int.Parse(split[0]);
                var max = int.Parse(split[1]);
                var character = split[2][0];
                var password = split[3];
                var includedAmount = password.Count(c => c == character);

                if (min <= includedAmount && includedAmount <= max)
                    correctPasswords++;
            }

            return correctPasswords;
        }
    }
}
