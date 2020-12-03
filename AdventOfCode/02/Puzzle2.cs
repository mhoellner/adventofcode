using System.Collections.Generic;

namespace AdventOfCode._02
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var correctPasswords = 0;

            foreach (var input in inputs)
            {
                var split = input.Split(' ', '-');
                var min = int.Parse(split[0]) - 1;
                var max = int.Parse(split[1]) - 1;
                var character = split[2][0];
                var password = split[3];

                var minMatch = password[min] == character;
                var maxMatch = max >= password.Length ? false : password[max] == character;

                if (minMatch ^ maxMatch)
                    correctPasswords++;
            }

            return correctPasswords;
        }
    }
}
