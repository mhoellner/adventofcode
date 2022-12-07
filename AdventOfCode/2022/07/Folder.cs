using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode._2022._07;

[DebuggerDisplay("dir {Name} ({Children.Count})")]
public class Folder : File
{
    public Folder(string name)
    {
        Name = name;
    }

    public void Add(File file)
    {
        Children.Add(file);
    }

    public override long Size => Children.Sum(f => f.Size);
    public override bool IsFolder => true;
    public List<File> Children { get; } = new List<File>();
}