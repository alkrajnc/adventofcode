namespace day6;

public class FileParser
{
    private readonly List<string> _lines = [];

    public FileParser(string filename)
    {
        var combinedPath =
            Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName,
                filename);

        if (!File.Exists(combinedPath))
        {
            Console.WriteLine("File not found");
        }

        using StreamReader sr = File.OpenText(combinedPath);
        string s;
        while ((s = sr.ReadLine()) != null)
        {
            _lines.Add(s);
        }
    }

    public List<string> Lines => _lines;


    public List<Problem> ParseFromLinesPartOne()
    {
        List<Problem> problems = [];

        var values = _lines[0].Split(" ");
        for (var i = 0; i < values.Length; i++)
        {
            if (values[i] is " " or "") continue;
            problems.Add(new Problem());
        }

        var k = 0;
        foreach (var line in _lines)
        {
            var lineValues = line.Split(" ");


            if (lineValues[0] == "*" || lineValues[0] == "+")
            {
                var j = 0;
                foreach (var operation in lineValues)
                {
                    if (operation is " " or "") continue;
                    problems[j].Operation = operation == "+" ? Operation.Add : Operation.Multiply;
                    j++;
                }
            }
            else
            {
                var j = 0;
                foreach (var num in lineValues)
                {
                    if (num is " " or "") continue;
                    problems[j].AddNumber(int.Parse(num.Replace(" ", "")));
                    j++;
                }
            }

            k++;
        }

        return problems;
    }
    
    public List<Problem> ParseFromLinesPartTwo()
    {
        List<Problem> problems = [];

        var values = _lines[0].Split(" ");
        for (var i = 0; i < values.Length; i++)
        {
            if (values[i] is " " or "") continue;
            problems.Add(new Problem());
        }

        var k = 0;
        foreach (var line in _lines)
        {
            var lineValues = line.Split(" ");


            if (lineValues[0] == "*" || lineValues[0] == "+")
            {
                var j = 0;
                foreach (var operation in lineValues)
                {
                    if (operation is " " or "") continue;
                    problems[j].Operation = operation == "+" ? Operation.Add : Operation.Multiply;
                    j++;
                }
            }
            else
            {
                var j = 0;
                foreach (var num in lineValues)
                {
                    if (num is " " or "") continue;
                    problems[j].AddNumber(int.Parse(num.Replace(" ", "")));
                    j++;
                }
            }

            k++;
        }

        return problems;
    }
}