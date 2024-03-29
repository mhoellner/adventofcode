﻿using System.Collections.Generic;
using System.IO;

namespace AdventOfCode
{
    public static class InputReader
    {
        public static List<string> Read(string path)
        {
            var result = new List<string>();
            using var file = File.OpenRead(path);
            using var sr = new StreamReader(file);
            while (!sr.EndOfStream)
                result.Add(sr.ReadLine());

            return result;
        }
    }
}
