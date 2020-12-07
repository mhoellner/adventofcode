using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._07
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var rules = new Dictionary<string, Dictionary<string, int>>();

            foreach(var input in inputs)
            {
                var rule = input.Split("contain ");
                var outerBag = rule[0].Split(" bags ")[0];
                if (rule[1] == "no other bags.")
                {
                    rules.Add(outerBag, new Dictionary<string, int>());
                    continue;
                }
                var innerBags = rule[1].Split(", ")
                    .Select(b => b.Split(' '))
                    .ToDictionary(a => $"{a[1]} {a[2]}", a => int.Parse(a[0]));
                rules.Add(outerBag, innerBags);
            }

            return CalculateInnerBags(rules, "shiny gold");
        }

        private long CalculateInnerBags(Dictionary<string, Dictionary<string, int>> rules, string bagColor)
        {
            var innerBags = rules.Where(r => r.Key == bagColor).Select(r => r.Value).ToArray();
            if (!innerBags.Any())
                return 0;

            return innerBags[0].Sum(b => b.Value + b.Value * CalculateInnerBags(rules, b.Key));
        }
    }
}
