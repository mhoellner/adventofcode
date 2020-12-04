using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._04
{
    public class Puzzle1 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var mandatoryFields = new[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            var passport = string.Empty;
            var count = 0;

            for (var i = 0; i < inputs.Count; i++)
            {
                if (inputs[i] == string.Empty)
                {
                    var fields = passport.Split(' ');
                    var hasAllMandatoryFields = mandatoryFields.All(m => fields.Any(f => f.StartsWith(m)));
                    if (hasAllMandatoryFields)
                        count++;
                    passport = string.Empty;
                    continue;
                }

                passport += $" {inputs[i]}";
            }

            return count;
        }
    }
}
