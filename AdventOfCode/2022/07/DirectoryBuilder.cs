using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2022._07;

public static class DirectoryBuilder
{
    public static void Build(IEnumerable<string> inputs, Folder root)
    {
        var current = root;
        foreach (var input in inputs.Skip(1))
        {
            if (input.StartsWith("$ ls"))
                continue;
            if (input.StartsWith("dir "))
            {
                var folder = new Folder(input.Split(" ")[1])
                {
                    Parent = current
                };
                current.Add(folder);
            }
            else if (input.StartsWith("$ cd .."))
            {
                current = current.Parent;
            }
            else if (input.StartsWith("$ cd "))
            {
                var folderName = input.Split(" ")[2];
                current = (Folder) current.Children.First(f => f.Name == folderName);
            }
            else
            {
                var parts = input.Split(" ");
                var file = new File(parts[1], long.Parse(parts[0]))
                {
                    Parent = current
                };
                current.Add(file);
            }
        }
    }
}