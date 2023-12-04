namespace AdventOfCode2023;

public static class DataProvider
{
    public static List<string> FromFile(string path)
    {
        var result = new List<string>();
        using var file = File.OpenRead(path);
        using var reader = new StreamReader(file);
        while (!reader.EndOfStream)
            result.Add(reader.ReadLine());

        return result;
    }
}