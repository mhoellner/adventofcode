using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventOfCode._2021._24;

public class Puzzle1 : IPuzzle
{
    public long Resolve(List<string> inputs)
    {
        for (var i = 99_999_999_999_999; i > 11_111_111_111_111; i--)
        {
            if (MonadArithmeticLogicUnit.ValidModelNumber(i.ToString()))
                return i;
        }
        
        throw new Exception("No valid model number found");

        // long highest = 0;
        // Parallel.For(11_111_111_111_111, 99_999_999_999_999, i =>
        // {
        //     if (MonadArithmeticLogicUnit.ValidModelNumber(i.ToString()) && i > highest)
        //         highest = i;
        // });
        //
        // return highest;
    }
}