using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._15
{
    public class Puzzle : IPuzzle
    {
        private readonly int _target;

        public Puzzle(int target = 1)
        {
            _target = target;
        }

        public long Resolve(List<string> inputs)
        {
            var array = new Vertex[inputs.Count * _target][];
            for (var index = 0; index < array.Length; index++)
            {
                array[index] = new Vertex[inputs[0].Length * _target];
            }

            for (var x = 0; x < inputs.Count; x++)
            for (var y = 0; y < inputs[0].Length; y++)
            for (var i = 0; i < _target; i++)
            for (var j = 0; j < _target; j++)
            {
                var value = int.Parse(inputs[x][y].ToString()) + i + j;
                if (value > 9)
                    value -= 9;
                var xi = x + i * inputs.Count;
                var yj = y + j * inputs[0].Length;
                array[xi][yj] = new Vertex(xi, yj, value);
            }

            array.First().First().Distance = 0;

            return GreedyDijkstra(array);
        }
        
        private static int GreedyDijkstra(IReadOnlyList<Vertex[]> array)
        {
            var queue = new List<Vertex>();
            var current = array.First().First();
            var last = array.Last().Last();

            while (current != last)
            {
                queue.Remove(current);
                var neighbours = GetNeighbours(array, current);
                foreach (var neighbour in neighbours)
                {
                    var distance = current.Distance + neighbour.Value;
                    if (distance >= neighbour.Distance)
                        continue;
                    neighbour.Distance = distance;
                    if (!queue.Contains(neighbour))
                        queue.Add(neighbour);
                }

                current = queue.Aggregate((min, x) => x.Distance < min.Distance ? x : min);
            }

            return current.Distance;
        }

        private static IEnumerable<Vertex> GetNeighbours(IReadOnlyList<Vertex[]> array, Vertex next)
        {
            var result = new List<Vertex>();
            if (next.X > 0)
                result.Add(array[next.X - 1][next.Y]);
            if (next.X < array.Count - 1)
                result.Add(array[next.X + 1][next.Y]);
            if (next.Y > 0)
                result.Add(array[next.X][next.Y - 1]);
            if (next.Y < array[0].Length - 1)
                result.Add(array[next.X][next.Y + 1]);
            
            return result;
        }
    }
}