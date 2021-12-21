using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._21
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var positions = inputs.Select(i => int.Parse(i.Split(": ")[1])).ToArray();
            var player1 = positions[0];
            var player2 = positions[1];
            var score1 = 0;
            var score2 = 0;

            var counter = 1;
            var isPlayer1 = true;
            while (score1 < 1000 && score2 < 1000)
            {
                if (isPlayer1)
                {
                    player1 = (player1 + 3 * counter + 3) % 10;
                    score1 += player1 == 0 ? 10 : player1;
                }
                else
                {
                    player2 = (player2 + 3 * counter + 3) % 10;
                    score2 += player2 == 0 ? 10 : player2;
                }

                isPlayer1 = !isPlayer1;
                counter += 3;
            }

            return (counter - 1) * (score1 > score2 ? score2 : score1);
        }
    }
}