using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._03
{
    public class Puzzle2 : IPuzzle
    {
        private string _oxygenFilter = "";
        private string _co2Filter = "";
        
        public long Resolve(List<string> inputs)
        {
            var oxygen = FindOxygenGeneratorRating(inputs, 0);
            var co2 = FindCO2ScrubberRating(inputs, 0);

            return oxygen * co2;
        }

        private long FindOxygenGeneratorRating(List<string> inputs, int position)
        {
            var counter = 0;
            foreach (var input in inputs)
                if (input[position] == '1')
                    counter++;

            if (counter >= inputs.Count / 2.0)
            {
                _oxygenFilter += "1";
            }
            else
            {
                _oxygenFilter += "0";
            }

            var remainingInputs = inputs.Where(i => i.StartsWith(_oxygenFilter)).ToList();
            
            if (remainingInputs.Count == 1)
                return Convert.ToInt64(remainingInputs[0], 2);

            return FindOxygenGeneratorRating(remainingInputs, position + 1);
        }

        private long FindCO2ScrubberRating(List<string> inputs, int position)
        {
            var counter = 0;
            foreach (var input in inputs)
                if (input[position] == '1')
                    counter++;

            if (counter >= inputs.Count / 2.0)
            {
                _co2Filter += "0";
            }
            else
            {
                _co2Filter += "1";
            }

            var remainingInputs = inputs.Where(i => i.StartsWith(_co2Filter)).ToList();

            if (remainingInputs.Count == 1)
                return Convert.ToInt64(remainingInputs[0], 2);

            return FindCO2ScrubberRating(remainingInputs, position + 1);
        }
    }
}