using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._11
{
    public static class Extensions
    {
        public static bool AreEqual(List<char[]> current, List<char[]> previous)
        {
            for (var i = 0; i < current.Count; i++)
                for (var j = 0; j < current[i].Length; j++)
                    if (current[i][j] != previous[i][j])
                        return false;
            return true;
        }

        public static List<char[]> Copy(this List<char[]> original)
        {
            return original.Select(a => {
                var arr = new char[a.Length];
                Array.Copy(a, arr, a.Length);
                return arr;
            }).ToList();
        }
    }
}
