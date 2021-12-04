using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._04
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var nextInputs = inputs[0].Split(',').Select(int.Parse);

            var boards = new List<BingoBoard>();
            var rows = new List<List<int>>();
            foreach (var row in inputs.ToArray()[2..])
                if (string.IsNullOrEmpty(row))
                {
                    boards.Add(new BingoBoard(rows));
                    rows = new List<List<int>>();
                }
                else
                {
                    var list = row.Split(" ").Where(s => !string.IsNullOrEmpty(s)).Select(int.Parse).ToList();
                    rows.Add(list);
                }

            foreach (var nextInput in nextInputs)
                for (var index = boards.Count - 1; index >= 0; index--)
                {
                    var board = boards[index];
                    if (board.PlayNext(nextInput))
                        if (boards.Count == 1)
                            return board.GetResult();
                        else
                            boards.Remove(board);
                }

            return 0;
        }
    }
}