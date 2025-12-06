namespace day6;

class Day6
{

    static long PartOne(List<Problem> problems)
    {
        var result = 0L;
        foreach (var problem in problems)
        {
            result += problem.Solve();
        }

        return result;
    }

    static long PartTwo(List<Problem> problems)
    {
        return 0L;
    }
    
    
    public static void Main()
    {
        var input = new FileParser("./input.txt");
        List<Problem> problemsPartOne = input.ParseFromLinesPartOne();
        List<Problem> problemsPartTwo = input.ParseFromLinesPartTwo();
   
    

        Console.WriteLine(PartOne(problemsPartOne));
        Console.WriteLine(PartTwo(problemsPartTwo));

    }
}