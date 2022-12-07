using System.Diagnostics;

namespace AdventOfCode._2022._07;

[DebuggerDisplay("{Size} {Name}")]
public class File
{
    protected File() { }
    
    public File(string name, long size)
    {
        Name = name;
        Size = size;
    }
    
    public string Name { get; protected init; }
    public virtual long Size { get; }
    public Folder Parent { get; init; }
    public virtual bool IsFolder => false;
}