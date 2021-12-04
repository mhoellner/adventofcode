using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020._06
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var count = 0;
            var groupInputs = new List<string>();

            for (var i = 0; i < inputs.Count; i++)
            {
                if (inputs[i] == string.Empty)
                {
                    foreach(var c in "abcdefghijklmnopqrstuvwxyz")
                    {
                        if (groupInputs.All(i => i.Contains(c)))
                            count++;
                    }
                    groupInputs = new List<string>();
                }
                else
                {
                    groupInputs.Add(inputs[i]);
                }
            }

            foreach (var c in "abcdefghijklmnopqrstuvwxyz")
            {
                if (groupInputs.All(i => i.Contains(c)))
                    count++;
            }

            return count;
        }
    }
}
