using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2022._01;

public class Puzzle2 : IPuzzle
{
    public Puzzle2(int amountOfElves = 3)
    {
        _amountOfElves = amountOfElves;
    }

    private readonly int _amountOfElves;
    public long Resolve(List<string> inputs)
    {
        var elves = new List<Elf>();
        var currentElf = new Elf();
        foreach (var input in inputs)
        {
            if (input == string.Empty)
            {
                elves.Add(currentElf);
                currentElf = new Elf();
            }
            else
            {
                currentElf.AddSnack(int.Parse(input));
            }
        }

        return elves.OrderByDescending(elf => elf.TotalCalories).Take(_amountOfElves).Sum(elf => elf.TotalCalories);
    }

    private class Elf
    {
        public int TotalCalories { get; private set; }
        
        public void AddSnack(int calories)
        {
            TotalCalories += calories;
        }
    }
}