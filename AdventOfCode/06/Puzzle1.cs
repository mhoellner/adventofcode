using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._06
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var count = 0;
            var groupInputs = new List<string>();

            for (var i = 0; i < inputs.Count; i++)
            {
                if (inputs[i] == string.Empty)
                {
                    count += groupInputs.SelectMany(i => i.ToArray()).Distinct().Count();
                    groupInputs = new List<string>();
                }
                else
                {
                    groupInputs.Add(inputs[i]);
                }
            }

            count += groupInputs.SelectMany(i => i.ToArray()).Distinct().Count();

            return count;
        }
    }
}
