using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2022._07;

public class Puzzle1 : IPuzzle
{
    public long Resolve(List<string> inputs)
    {
        var root = new Folder("/");
        DirectoryBuilder.Build(inputs, root);

        return SumFolderWithAtMost100000(root);
    }

    private long SumFolderWithAtMost100000(Folder folder)
    {
        return (folder.Size <= 100_000 ? folder.Size : 0) +
               folder.Children
                   .Where(f => f.IsFolder)
                   .Sum(f => SumFolderWithAtMost100000((Folder)f));
    }
}