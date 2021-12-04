using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020._13
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            long earliestDeparture = long.Parse(inputs[0]);
            var availableBusses = inputs[1].Split(',').Where(b => b != "x").Select(int.Parse).ToArray();
            long nextTry = earliestDeparture;

            while (true)
            {
                nextTry++;
                var foundBus = availableBusses.SingleOrDefault(b => nextTry % b == 0);
                if (foundBus != default(int))
                    return (nextTry - earliestDeparture) * foundBus;
            };
        }
    }
}
