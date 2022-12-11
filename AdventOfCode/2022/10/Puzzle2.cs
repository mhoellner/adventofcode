using System.Collections.Generic;

namespace AdventOfCode._2022._10;

public class Puzzle2
{
    private int _register;
    private int _cycle;
    private string _result;

    public string Resolve(List<string> inputs)
    {
        _register = 1;
        _cycle = 1;
        _result = "";

        foreach (var input in inputs)
        {
            if (input == "noop")
            {
                DrawPixel();
                _cycle++;
            }
            else if (input.StartsWith("addx"))
            {
                DrawPixel();
                _cycle++;
                DrawPixel();
                _cycle++;
                _register += int.Parse(input.Split(' ')[1]);
            }
        }

        return _result;
    }

    private void DrawPixel()
    {
        var crtPos = (_cycle - 1) % 40;
        if (_register - 1 <= crtPos && crtPos <= _register + 1)
            _result += "#";
        else
            _result += ".";
        if (_cycle % 40 == 0)
            _result += "\n";
    }
}