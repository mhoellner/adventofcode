using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2022._07;

public class Puzzle2 : IPuzzle
{
    private long _target;
    private long _best;

    public long Resolve(List<string> inputs)
    {
        var root = new Folder("/");
        DirectoryBuilder.Build(inputs, root);

        _target = 30_000_000 - (70_000_000 - root.Size);
        _best = root.Size;

        FindBestFolderToDelete(root);

        return _best;
    }

    private void FindBestFolderToDelete(Folder folder)
    {
        if (folder.Size >= _target)
        {
            if (folder.Size < _best)
            {
                _best = folder.Size;
            }
            foreach (var child in folder.Children
                         .Where(f => f.IsFolder)
                         .Select(f => (Folder) f))
            {
                FindBestFolderToDelete(child);
            }
        }
    }
}