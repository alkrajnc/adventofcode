namespace Day4;

public class RollStorage(string path)
{
    public List<char[]> lines = [];


    private List<Tuple<int, int>> _offsets =
        [new(-1, -1), new(-1, 0), new(-1, 1), new(0, -1), new(0, 1), new(1, -1), new(1, 0), new(1, 1)];

    public void ReadFromFile()
    {
        var combinedPath =
            Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName, path);

        if (!File.Exists(combinedPath))
        {
            Console.WriteLine("File not found");
        }

        using StreamReader sr = File.OpenText(combinedPath);
        string s;
        while ((s = sr.ReadLine()) != null)
        {
            lines.Add(s.ToCharArray());
        }
    }

    private bool IsIndexRangeValid(int row, int col)
    {
        if (row < 0 || row >= lines.Count)
        {
            return false;
        }

        if (col < 0 || col >= lines.Count)
        {
            return false;
        }

        return true;
    }

    public bool LessThanFourNeighbouringRolls(int row, int col)
    {
        var neighboringRollsCount = 0;

        foreach (var offset in _offsets)
        {
            if (IsIndexRangeValid(row + offset.Item1, col + offset.Item2) &&
                lines[row + offset.Item1][col + offset.Item2] == '@')
            {
                neighboringRollsCount++;
            }
        }

        return neighboringRollsCount < 4;
    }
}