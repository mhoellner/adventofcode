using System;

namespace AdventOfCode._2020._05
{
    public static class Extensions
    {
        public static int BinarySearch(int min, int max, char lower, char upper, string input)
        {
            if (min == max)
                return min;

            var next = input[0];
            if (next == upper)
                return BinarySearch(Convert.ToInt32(Math.Ceiling((decimal)(min + max) / 2)), max, lower, upper, input[1..]);
            else if (next == lower)
                return BinarySearch(min, Convert.ToInt32(Math.Floor((decimal)(min + max) / 2)), lower, upper, input[1..]);
            throw new ArgumentException("The next input is neither upper nor lower", nameof(next));
        }
    }
}
