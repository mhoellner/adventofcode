using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._10
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            return inputs.Select(CalculateErrorScore).Sum();
        }

        private static long CalculateErrorScore(string input)
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
                else if (c == ')')
                    return 3;
                else if (c == ']')
                    return 57;
                else if (c == '}')
                    return 1197;
                else if (c == '>')
                    return 25137;
            }

            return 0;
        }
    }
}