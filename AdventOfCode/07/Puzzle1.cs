using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._07
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var rules = new Dictionary<string, List<string>>();

            for (var i = 0; i < inputs.Count; i++)
            {
                var rule = inputs[i].Split("contain ");
                var outerBag = rule[0].Split(" bags ")[0];
                if (rule[1] == "no other bags.")
                {
                    rules.Add(outerBag, new List<string>());
                    continue;
                }
                var innerBags = rule[1].Split(", ").Select(b => b.Split(' ')).Select(a => $"{a[1]} {a[2]}").ToList();
                rules.Add(outerBag, innerBags);
            }

            var foundColors = new List<string>();
            MatchRules(rules, foundColors, "shiny gold");

            return foundColors.Count;
        }

        private void MatchRules(Dictionary<string, List<string>> rules, List<string> foundColors, string bagColor)
        {
            var outerColors = rules.Where(r => r.Value.Contains(bagColor)).Select(r => r.Key);
            if (outerColors.All(r => foundColors.Contains(r)))
                return;

            foundColors.AddRange(outerColors.Where(c => !foundColors.Contains(c)));

            foreach (var outerColor in outerColors)
            {
                MatchRules(rules, foundColors, outerColor);
            }
        }
    }
}
