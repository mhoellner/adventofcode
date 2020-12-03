using System.Collections.Generic;

namespace AdventOfCode
{
    public interface IPuzzle
    {
        long Resolve(List<string> inputs);
    }
}
