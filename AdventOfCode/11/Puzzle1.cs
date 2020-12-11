using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._11
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            List<char[]> previous;
            var current = new List<char[]>(inputs.Select(s => s.ToArray()));

            do
            {
                previous = current.Copy();
                for (var i = 0; i < current.Count; i++)
                {
                    for (var j = 0; j < current[i].Length; j++)
                    {
                        if (previous[i][j] == 'L')
                        {
                            if (SomeoneWantsToSit(previous, i, j))
                                current[i][j] = '#';
                        }
                        else if (previous[i][j] == '#')
                        {
                            if (SomeoneWantsToLeave(previous, i, j))
                                current[i][j] = 'L';
                        }
                    }
                }
            } while (!Extensions.AreEqual(current, previous));

            return current.SelectMany(i => i).Count(current => current == '#');
        }

        private bool SomeoneWantsToSit(List<char[]> allSeats, int i, int j) => AmountOfOccupiedSeats(allSeats, i, j) == 0;

        private bool SomeoneWantsToLeave(List<char[]> allSeats, int i, int j) => AmountOfOccupiedSeats(allSeats, i, j) >= 4;

        private int AmountOfOccupiedSeats(List<char[]> allSeats, int i, int j)
        {
            int amount = 0;

            for (var ic = i - 1; ic < i + 2; ic++)
            {
                for (var jc = j - 1; jc < j + 2; jc++)
                {
                    if (ic == i && jc == j)
                        continue;
                    if (ic >= 0 && ic < allSeats.Count && jc >= 0 && jc < allSeats[0].Length && allSeats[ic][jc] == '#')
                        amount++;
                }
            }

            return amount;
        }
    }
}
