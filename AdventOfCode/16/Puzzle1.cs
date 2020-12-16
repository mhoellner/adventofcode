using System.Collections.Generic;

namespace AdventOfCode._16
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var rules = new List<Rule>();
            var errorRate = 0;
            bool isNearbyTicket = false;

            foreach (var input in inputs)
            {
                if (isNearbyTicket)
                    errorRate += Extensions.GetInvalidField(input, rules);

                if (input.Contains(": "))
                    rules.Add(Rule.FromInput(input));

                if (input == "nearby tickets:")
                    isNearbyTicket = true;
            }

            return errorRate;
        }
    }
}
