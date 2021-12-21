using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._21
{
    public class Puzzle2 : IPuzzle
    {
        private readonly Dictionary<int, int> _possibilityMap = new Dictionary<int, int>
        {
            {3, 1},
            {4, 3},
            {5, 6},
            {6, 7},
            {7, 6},
            {8, 3},
            {9, 1}
        };

        public long Resolve(List<string> inputs)
        {
            var positions = inputs.Select(i => int.Parse(i.Split(": ")[1])).ToArray();
            var player1 = positions[0];
            var player2 = positions[1];

            var (player1Wins, player2Wins) = Play(player1, player2, 0, 0, true);

            return player1Wins > player2Wins ? player1Wins : player2Wins;
        }

        private (long player1Wins, long player2Wins) Play(int player1, int player2, int score1, int score2, bool isPlayer1)
        {
            var result = new List<(long, long)>();
            foreach (var i in new []{ 3, 4, 5, 6, 7, 8, 9})
            {
                (long, long) pair;
                if (isPlayer1)
                {
                    var nextPlayer1 = (player1 + i) % 10;
                    var res = score1 + (nextPlayer1 == 0 ? 10 : nextPlayer1);
                    pair = res >= 21
                        ? (1, 0)
                        : Play(nextPlayer1, player2, res, score2, false);
                }
                else
                {
                    var nextPlayer2 = (player2 + i) % 10;
                    var res = score2 + (nextPlayer2 == 0 ? 10 : nextPlayer2);
                    pair = res >= 21
                        ? (0, 1)
                        : Play(player1, nextPlayer2, score1, res, true);
                }
                
                result.Add((pair.Item1 * _possibilityMap[i], pair.Item2 * _possibilityMap[i]));
            }

            return (result.Sum(p => p.Item1), result.Sum(p => p.Item2));
        }
    }
}