using System.Collections.Generic;

namespace AdventOfCode._18
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var sum = 0L;

            for (var i = 0; i < inputs.Count; i++)
            {
                var input = inputs[i];
                while (input.Contains("("))
                {
                    var oi = input.LastIndexOf('(');
                    var ci = input.IndexOf(')', oi);
                    var ss = input.Substring(oi + 1, ci - oi - 1);
                    var rs = input.Substring(oi, ci - oi + 1);
                    input = input.Replace(rs, DoMath(ss.Split(" ")).ToString());
                }

                sum += DoMath(input.Split(" "));
            }

            return sum;
        }

        private long DoMath(string[] v)
        {
            var result = long.Parse(v[0]);
            for (var i = 2; i < v.Length; i += 2)
            {
                if (v[i - 1] == "+")
                    result += long.Parse(v[i]);
                else
                    result *= long.Parse(v[i]);
            }

            return result;
        }
    }
}
