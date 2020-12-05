using System.Collections.Generic;

namespace AdventOfCode._05
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var allSeats = new List<int>();

            for (var i = 0; i < inputs.Count; i++)
            {
                var columnCode = inputs[i][0..8];
                var seatCode = inputs[i][7..10];

                var seatId = CalculateColumn(columnCode) * 8 + CalculateSeat(seatCode);
                allSeats.Add(seatId);
            }

            allSeats.Sort();

            var emptySeat = 0;

            for (var i = 0; i < allSeats.Count; i++)
            {
                if (i > 0)
                {
                    var current = allSeats[i];
                    var previous = allSeats[i - 1];
                    if (current == previous + 2)
                        emptySeat = previous + 1;
                }
            }

            return emptySeat;
        }

        private int CalculateColumn(string columnCode) => Extensions.BinarySearch(0, 127, 'F', 'B', columnCode);
        private int CalculateSeat(string seatCode) => Extensions.BinarySearch(0, 7, 'L', 'R', seatCode);
    }
}
