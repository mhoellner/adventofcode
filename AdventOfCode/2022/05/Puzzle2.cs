using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2022._05;

public class Puzzle2
{
    private Stack<char>[] _stacks;
    public string Resolve(List<string> inputs)
    {
        InitializeStacks(inputs);
        UseCrane(inputs);

        return new string(_stacks.Select(s => s.Peek()).ToArray());
    }

    private void InitializeStacks(List<string> inputs)
    {
        _stacks = new Stack<char>[9];
        for (var index = 0; index < 9; index++)
        {
            var stack = new Stack<char>();
            _stacks[index] = stack;

            for (var rowIndex = 7; rowIndex >= 0; rowIndex--)
            {
                var towerIndex = (index + 1) * 4 - 3;
                var container = inputs[rowIndex][towerIndex];
                if (container != ' ')
                    stack.Push(container);
            }
        }
    }

    private void UseCrane(List<string> inputs)
    {
        foreach (var input in inputs.Skip(10))
        {
            if (input == String.Empty)
                return;

            var steps = input.Split(' ');
            var move = int.Parse(steps[1]);
            var from = int.Parse(steps[3]);
            var to = int.Parse(steps[5]);

            var list = new List<char>();
            for (var step = 0; step < move; step++)
            {
                list.Add(_stacks[from - 1].Pop());
            }

            list.Reverse();
            foreach (var step in list)
            {
                _stacks[to - 1].Push(step);
            }
        }
    }
}