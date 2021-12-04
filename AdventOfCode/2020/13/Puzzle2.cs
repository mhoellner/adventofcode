using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2020._13
{
    public class Puzzle2 : IPuzzle
    {
        public long Start { get; set; } = 100_000_000_000_000;

        public long Resolve(List<string> inputs)
        {
            var busses = inputs[1].Split(',');
            var offsets = new List<(long id, int offset)>();
            for (var index = 0; index < busses.Length; index++)
            {
                if (busses[index] != "x")
                    offsets.Add((long.Parse(busses[index]), index));
            }
            offsets = offsets.OrderByDescending(o => o).ToList();

            long timestamp = GetFirstMatchFirst(Start, offsets[0]);
            var multiplier = offsets[0].id;
            int unsatisfied = 1;
            
            while (unsatisfied < offsets.Count)
            {
                timestamp += multiplier;
                var next = offsets[unsatisfied];

                if ((timestamp + next.offset) % next.id == 0)
                {
                    multiplier *= next.id;
                    unsatisfied++;
                }
            }

            return timestamp;
        }

        private long GetFirstMatchFirst(long start, (long id, int offset) offset)
        {
            while (true)
            {
                if ((start + offset.offset) % offset.id == 0)
                    return start;

                start++;
            };
        }
    }
}
