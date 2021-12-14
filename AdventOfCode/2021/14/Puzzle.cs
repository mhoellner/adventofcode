using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._14
{
    public class Puzzle : IPuzzle
    {
        private readonly int _target;

        public Puzzle(int target)
        {
            _target = target;
        }

        public long Resolve(List<string> inputs)
        {
            var solution = new Dictionary<string, long>();
            for (var index = 0; index < inputs[0].Length - 1; index++)
            {
                var key = inputs[0].Substring(index, 2);
                if (solution.ContainsKey(key))
                    solution[key] += 1;
                else
                    solution.Add(key, 1);
            }

            var lastElement = inputs[0].Last();
            
            var rules = new Dictionary<string, string>();
            for (var index = 2; index < inputs.Count; index++)
            {
                var s = inputs[index].Split(" -> ");
                rules.Add(s[0], s[1]);
            }

            for (var index = 0; index < _target; index++)
            {
                var tempSolution = new Dictionary<string, long>();
                foreach (var rule in rules)
                {
                    if (solution.ContainsKey(rule.Key))
                    {
                        var value = solution[rule.Key];

                        var key1 = $"{rule.Key[0]}{rule.Value}";
                        if (tempSolution.ContainsKey(key1))
                            tempSolution[key1] += value;
                        else
                            tempSolution.Add(key1, value);
                        var key2 = $"{rule.Value}{rule.Key[1]}";
                        if (tempSolution.ContainsKey(key2))
                            tempSolution[key2] += value;
                        else
                            tempSolution.Add(key2, value);
                    }
                }

                solution = tempSolution;
            }

            var elementCounts = new Dictionary<char, long>();
            foreach (var pair in solution)
            {
                var c = pair.Key[0];
                if (elementCounts.ContainsKey(c))
                    elementCounts[c] += pair.Value;
                else
                    elementCounts.Add(c, pair.Value);
            }

            elementCounts[lastElement] += 1;

            return elementCounts.Max(e => e.Value) - elementCounts.Min(e => e.Value);
        }
    }
}