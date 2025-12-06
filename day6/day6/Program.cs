namespace day6;

internal static class Day6
{
    static long Calculate(List<Problem> problems)
    {
        var result = 0L;
        foreach (var problem in problems)
        {
            result += problem.Solve();
        }

        return result;
    }


    public static void Main()
    {
        var input = new FileParser("./input.txt");
        var problemsPartOne = input.ParseFromLinesPartOne();
        var problemsPartTwo = input.ParseFromLinesPartTwo();

        Console.WriteLine(Calculate(problemsPartOne));
        Console.WriteLine(Calculate(problemsPartTwo));
    }
}