using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020._16
{
    public static class Extensions
    {
        public static int GetInvalidField(string ticket, IEnumerable<Rule> rules)
            => ticket.Split(",").Select(int.Parse).SingleOrDefault(value => rules.All(r => !r.Matches(value)));
    }
}
