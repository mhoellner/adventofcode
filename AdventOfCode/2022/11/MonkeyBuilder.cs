using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2022._11;

internal static class MonkeyBuilder
{
    internal static Monkey[] ParseMonkeys(List<string> inputs)
    {
        var monkeys = new List<Monkey>();
        for (var index = 0; index < inputs.Count;)
        {
            var items = inputs[index + 1].Split(": ")[1].Split(", ").Select(long.Parse).ToArray();
            var divider = int.Parse(inputs[index + 3].Split("by ")[1]);
            var trueMonkey = int.Parse(inputs[index + 4].Split("monkey ")[1]);
            var falseMonkey = int.Parse(inputs[index + 5].Split("monkey ")[1]);
            var monkey = new Monkey(divider, trueMonkey, falseMonkey, items);
            var operation = inputs[index + 2].Split("new = old ")[1];
            if (operation == "* old")
                monkey.Operation = Square();
            else if (operation.StartsWith("* "))
                monkey.Operation = Multiply(int.Parse(operation.Split(' ')[1]));
            else if (operation.StartsWith("+ "))
                monkey.Operation = Add(int.Parse(operation.Split(' ')[1]));

            monkeys.Add(monkey);
            index += 7;
        }

        return monkeys.ToArray();
    }

    private static Func<long, long> Multiply(int x) => i => i * x;
    private static Func<long, long> Add(int x) => i => i + x;
    private static Func<long, long> Square() => i => i * i;
}