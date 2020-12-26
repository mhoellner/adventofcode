using System.Collections.Generic;

namespace AdventOfCode._18
{
    public class Puzzle2 : IPuzzle
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
                    input = input.Replace(rs, DoMath(ss).ToString());
                }

                sum += DoMath(input);
            }

            return sum;
        }

        private long DoMath(string v)
        {
            var input = new string(v);
            while (input.Contains("+"))
            {
                var pi = input.IndexOf("+");
                var si = input.Substring(0, pi - 1).LastIndexOf(" ") + 1;
                var li = input.Substring(pi).IndexOf(" ", 2);
                li = li == -1 ? input.Length - si : pi + li - si;
                var ss = input.Substring(si, li);
                var vals = ss.Split(" ");
                var res = long.Parse(vals[0]) + long.Parse(vals[2]);
                input = input.Replace(ss, res.ToString());
            }

            var arr = input.Split(" ");
            var result = long.Parse(arr[0]);
            for (var i = 2; i < arr.Length; i += 2)
            {
                result *= long.Parse(arr[i]);
            }

            return result;
        }
    }
}
