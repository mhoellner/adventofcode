using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2022._09;

public class Puzzle1 :  IPuzzle
{
    public long Resolve(List<string> inputs)
    {
        var instructions = ParseInstructions(inputs);
        var (field, offsetX, offsetY) = InitializeField(instructions);
        MoveToTheOtherSide(field, instructions, offsetX, offsetY);

        return field.Sum(c => c.Count(f => f));
    }

    private List<(char direction, int step)> ParseInstructions(List<string> inputs)
    {
        return inputs.Select(i =>
        {
            var s = i.Split(' ');
            return (s[0][0], int.Parse(s[1]));
        }).ToList();
    }

    private static (bool[][] field, int offsetX, int offsetY) InitializeField(List<(char direction, int step)> instructions)
    {
        var maxX = 0;
        var minX = 0;
        var currentX = 0;
        var maxY = 0;
        var minY = 0;
        var currentY = 0;

        foreach (var (direction, step) in instructions)
        {
            switch (direction)
            {
                case 'R':
                    currentX += step;
                    if (currentX > maxX)
                        maxX = currentX;
                    break;
                case 'L':
                    currentX -= step;
                    if (currentX < minX)
                        minX = currentX;
                    break;
                case 'U':
                    currentY += step;
                    if (currentY > maxY)
                        maxY = currentY;
                    break;
                case 'D':
                    currentY -= step;
                    if (currentY < minY)
                        minY = currentY;
                    break;
            }
        }
        
        var field = new bool[maxX - minX][];
        for (var index = 0; index < field.Length; index++) 
            field[index] = new bool[maxY - minY];

        return (field, -minX, -minY);
    }

    private static void MoveToTheOtherSide(bool[][] field, List<(char direction, int step)> instructions, int offsetX, int offsetY)
    {
        var headX = offsetX;
        var headY = offsetY;
        var tailX = offsetX;
        var tailY = offsetY;
        field[tailX][tailY] = true;

        foreach (var (direction, step) in instructions)
        {
            for (var i = 0; i < step; i++)
            {
                // move head
                switch (direction)
                {
                    case 'R':
                        headX++;
                        break;
                    case 'L':
                        headX--;
                        break;
                    case 'U':
                        headY++;
                        break;
                    case 'D':
                        headY--;
                        break;
                }
                
                // move tail
                if (headX == tailX + 2)
                {
                    tailX++;
                    if (headY == tailY + 1)
                        tailY++;
                    else if (headY == tailY - 1)
                        tailY--;
                }
                else if (headX == tailX - 2)
                {
                    tailX--;
                    if (headY == tailY + 1)
                        tailY++;
                    else if (headY == tailY - 1)
                        tailY--;
                }
                else if (headY == tailY + 2)
                {
                    tailY++;
                    if (headX == tailX + 1)
                        tailX++;
                    else if (headX == tailX - 1)
                        tailX--;
                }
                else if (headY == tailY - 2)
                {
                    tailY--;
                    if (headX == tailX + 1)
                        tailX++;
                    else if (headX == tailX - 1)
                        tailX--;
                }

                field[tailX][tailY] = true;
            }
        }
    }
}