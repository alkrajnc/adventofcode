using Day4;


class day4
{
    static int PartOne(RollStorage storage)
    {
        var count = 0;

        for (int i = 0; i < storage.lines.Count; i++)
        {
            for (int j = 0; j < storage.lines[i].Length; j++)
            {
                if (storage.lines[i][j] != '@') continue;
                if (storage.LessThanFourNeighbouringRolls(i, j))
                {
                    count++;
                }
            }
        }

        return count;
    }

    static int PartTwo(RollStorage storage)
    {
        var totalRemovedCount = 0;
        while (true)
        {
            var cellsToRemove = new List<(int row, int col)>();
            for (var i = 0; i < storage.lines.Count; i++)
            {
                for (var j = 0; j < storage.lines[i].Length; j++)
                {
                    if (storage.lines[i][j] != '@') continue;
                    if (!storage.LessThanFourNeighbouringRolls(i, j)) continue;
                    cellsToRemove.Add((i, j));
                }
            }

            foreach (var (row, col) in cellsToRemove)
            {
                storage.lines[row][col] = 'x';
            }

            totalRemovedCount += cellsToRemove.Count;

            if (cellsToRemove.Count == 0) break;
        }

        return totalRemovedCount;
    }

    public static void Main()
    {
        var storage = new RollStorage("./input.txt");
        storage.ReadFromFile();

        Console.WriteLine(PartOne(storage));
        Console.WriteLine(PartTwo(storage));
    }
}