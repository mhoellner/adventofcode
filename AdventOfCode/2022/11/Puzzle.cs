using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2022._11;

public class Puzzle : IPuzzle
{
    private readonly int _rounds;
    private readonly bool _isPartTwo;

    public Puzzle(int rounds = 20, bool isPartTwo = false)
    {
        _rounds = rounds;
        _isPartTwo = isPartTwo;
    }
    
    public long Resolve(List<string> inputs)
    {
        var monkeys = MonkeyBuilder.ParseMonkeys(inputs);
        
        if (_isPartTwo)
            Monkey.DecreaseWorryLevel = item => item % LeastCommonMultiple(monkeys.Select(m => m.Divider).ToArray());

        for (var round = 0; round < _rounds; round++)
        {
            foreach (var monkey in monkeys)
            {
                while (monkey.TryInspect(out var result))
                {
                    monkeys[result.monkey].AddItem(result.item);
                }
            }
        }

        var ordered = monkeys.OrderByDescending(x => x.InspectionCounter).ToArray();
        return (long) ordered[0].InspectionCounter * ordered[1].InspectionCounter;
    }

    private static long LeastCommonMultiple(int[] numbers)
    {
        var answer = numbers[0];
        for (var index = 1; index < numbers.Length; index++)
            answer = numbers[index] * answer / GreatestCommonDivisor(numbers[index], answer);
        return answer;
    }

    private static int GreatestCommonDivisor(int a, int b) => b == 0 ? a : GreatestCommonDivisor(b, a % b);
}