using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020._16
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var rules = new List<Rule>();
            var isNearbyTicket = false;
            var isMyTicket = false;
            var myTicket = new int[0];
            var validTickets = new List<int[]>();

            foreach (var input in inputs)
            {
                if (input == string.Empty)
                    continue;
                else if (input == "nearby tickets:")
                    isNearbyTicket = true;
                else if (input == "your ticket:")
                    isMyTicket = true;
                else if (isNearbyTicket)
                    if (Extensions.GetInvalidField(input, rules) == 0)
                        validTickets.Add(input.Split(',').Select(int.Parse).ToArray());
                    else { }
                else if (isMyTicket)
                    myTicket = input.Split(',').Select(int.Parse).ToArray();
                else if (input.Contains(": "))
                    rules.Add(Rule.FromInput(input));
            }

            var identifiedRules = new Dictionary<int, Rule>();
            var remainingRules = new List<Rule>(rules);

            while (identifiedRules.Count(r => r.Value.Name.StartsWith("departure")) < 6)
            {
                for (var i = 0; i < validTickets[0].Length; i++)
                {
                    var identifiedRule = remainingRules.Where(r => validTickets.All(t => r.Matches(t[i])));
                    if (identifiedRule.Count() == 1)
                        identifiedRules.Add(i, identifiedRule.Single());
                }

                remainingRules = new List<Rule>(rules.Except(identifiedRules.Values));
            }

            var departureRules = identifiedRules.Where(r => r.Value.Name.StartsWith("departure"));
            return departureRules.Aggregate(1L, (aggregate, kvp) => aggregate * myTicket[kvp.Key]);
        }
    }
}
