using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._10
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var scores = inputs.Select(CalculateScore).Where(s => s != 0).OrderBy(s => s).ToList();

            return scores[scores.Count / 2];
        }

        private static long CalculateScore(string input)
        {
            var stack = new Stack<char>();
            foreach (var c in input)
            {
                if (c == '(' ||
                    c == '[' ||
                    c == '{' ||
                    c == '<')
                    stack.Push(c);
                else if (c == ')' && stack.Peek() == '(' ||
                         c == ']' && stack.Peek() == '[' ||
                         c == '}' && stack.Peek() == '{' ||
                         c == '>' && stack.Peek() == '<')
                    stack.Pop();
                else return 0;
            }

            var score = 0L;
            while (stack.TryPop(out var c))
            {
                score *= 5;
                if (c == '(')
                    score += 1;
                else if (c == '[')
                    score += 2;
                else if (c == '{')
                    score += 3;
                else if (c == '<')
                    score += 4;
            }

            return score;
        }
    }
}