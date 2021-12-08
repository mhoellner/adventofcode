using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode._2021._08
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            return inputs.Select(i => i.Split(" | ")).Select(arr => Decode(arr[0].Split(" "), arr[1].Split(" "))).Sum();
        }

        private long Decode(string[] input, string[] output)
        {
            var dict = new Dictionary<string, string>();
            var remainingInput = new List<string>(input);
            var one = remainingInput.Single(i => i.Length == 2);
            remainingInput.Remove(one);
            dict.Add("1", one);
            var four = remainingInput.Single(i => i.Length == 4);
            remainingInput.Remove(four);
            dict.Add("4", four);
            var seven = remainingInput.Single(i => i.Length == 3);
            remainingInput.Remove(seven);
            dict.Add("7", seven);
            var eight = remainingInput.Single(i => i.Length == 7);
            remainingInput.Remove(eight);
            dict.Add("8", eight);
            var nine = remainingInput.Single(i => four.All(i.Contains));
            remainingInput.Remove(nine);
            dict.Add("9", nine);
            var zero = remainingInput.Single(i => i.Length == 6 && one.All(i.Contains));
            remainingInput.Remove(zero);
            dict.Add("0", zero);
            var three = remainingInput.Single(i => i.Length == 5 && one.All(i.Contains));
            remainingInput.Remove(three);
            dict.Add("3", three);
            var six = remainingInput.Single(i => i.Length == 6);
            remainingInput.Remove(six);
            dict.Add("6", six);
            var five = remainingInput.OrderByDescending(i => i.Count(c => six.Contains(c))).First();
            dict.Add("5", five);
            remainingInput.Remove(five);
            dict.Add("2", remainingInput.Single());

            var outputString = output
                .Select(o => dict.Single(p => o.Length == p.Value.Length && o.All(p.Value.Contains)).Key)
                .Aggregate(string.Empty, (s, s1) => s + s1);

            return int.Parse(outputString);
        }
    }
}