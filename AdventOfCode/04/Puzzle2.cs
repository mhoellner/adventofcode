using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._04
{
    public class Puzzle2 : IPuzzle
    {
        public long Resolve(List<string> inputs)
        {
            var count = 0;
            var passport = string.Empty;

            for (var i = 0; i < inputs.Count; i++)
            {
                if (inputs[i] != string.Empty)
                {
                    passport += $" {inputs[i]}";
                    continue;
                }

                var fields = passport.Split(' ').Select(f => f.Split(':')).ToArray();
                bool allRulesValid =
                    ValidBirthYear(fields) &&
                    ValidIssueYear(fields) &&
                    ValidExpirationYear(fields) &&
                    ValidHeight(fields) &&
                    ValidHairColor(fields) &&
                    ValidEyeColor(fields) &&
                    ValidPassportId(fields);
                if (allRulesValid)
                    count++;
                passport = string.Empty;
            }

            return count;
        }

        private bool ValidBirthYear(string[][] fields) => fields.Any(f => f[0] == "byr" && int.TryParse(f[1], out var byr) && byr >= 1920 && byr <= 2002);
        private bool ValidIssueYear(string[][] fields) => fields.Any(f => f[0] == "iyr" && int.TryParse(f[1], out var iyr) && iyr >= 2010 && iyr <= 2020);
        private bool ValidExpirationYear(string[][] fields) => fields.Any(f => f[0] == "eyr" && int.TryParse(f[1], out var eyr) && eyr >= 2020 && eyr <= 2030);
        private bool ValidHeight(string[][] fields) => fields.Any(f => f[0] == "hgt" &&
            ((f[1].EndsWith("cm") && int.TryParse(f[1][0..3], out var cm) && cm >= 150 && cm <= 193) ||
            (f[1].EndsWith("in") && int.TryParse(f[1][0..2], out var inch) && inch >= 59 && inch <= 76)));
        private bool ValidHairColor(string[][] fields) => fields.Any(f => f[0] == "hcl" && f[1][0] == '#' && f[1].Length == 7 &&
            int.TryParse(f[1][1..], System.Globalization.NumberStyles.HexNumber, null, out _));
        private bool ValidEyeColor(string[][] fields) => fields.Any(f => f[0] == "ecl" &&
            (f[1] == "amb" || f[1] == "blu" || f[1] == "brn" || f[1] == "gry" || f[1] == "grn" || f[1] == "hzl" || f[1] == "oth"));
        private bool ValidPassportId(string[][] fields) => fields.Any(f => f[0] == "pid" && f[1].Length == 9 && int.TryParse(f[1], out _));
    }
}
