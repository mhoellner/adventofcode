using System.Collections.Generic;

namespace AdventOfCode._2020._05
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var highestSeatId = 0;

            for (var i = 0; i < inputs.Count; i++)
            {
                var columnCode = inputs[i][0..8];
                var seatCode = inputs[i][7..10];

                var seatId = CalculateColumn(columnCode) * 8 + CalculateSeat(seatCode);
                if (seatId > highestSeatId)
                    highestSeatId = seatId;
            }

            return highestSeatId;
        }

        private int CalculateColumn(string columnCode) => Extensions.BinarySearch(0, 127, 'F', 'B', columnCode);
        private int CalculateSeat(string seatCode) => Extensions.BinarySearch(0, 7, 'L', 'R', seatCode);
    }
}
