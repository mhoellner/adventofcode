using System;
using System.Collections.Generic;

namespace AdventOfCode._2022._11;

internal class Monkey
{
    public Monkey(int divider, int trueMonkey, int falseMonkey, params long[] items)
    {
        Divider = divider;
        _trueMonkey = trueMonkey;
        _falseMonkey = falseMonkey;
        foreach (var item in items)
        {
            _items.Enqueue(item);
        }
    }
    
    private readonly Queue<long> _items = new();
    public int Divider { get; }
    private readonly int _trueMonkey;
    private readonly int _falseMonkey;
    public Func<long, long> Operation;
    public static Func<long, long> DecreaseWorryLevel = item => item / 3;
    public int InspectionCounter { get; private set; }

    public bool TryInspect(out (int monkey, long item) _)
    {
        _ = (0, 0);
        if (!_items.TryDequeue(out var item))
            return false;

        var worryLevel = DecreaseWorryLevel(Operation(item));
        InspectionCounter++;

        _ = (worryLevel % Divider == 0 ? _trueMonkey : _falseMonkey, worryLevel);
        return true;
    }

    public void AddItem(long item) => _items.Enqueue(item);
}