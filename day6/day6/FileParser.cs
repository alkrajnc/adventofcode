using System.Text.RegularExpressions;

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
        foreach (var t in values)
        {
            if (t is " " or "") continue;
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


    private static bool IsNumber(char num)
    {
        return num >= 48 && num <= 57;
    }


    public List<Problem> ParseFromLinesPartTwo()
    {
        List<Problem> problems = [];
        List<Offset> offsets = [];

        var values = _lines.Last();
        for (var i = 0; i < values.Length; i++)
        {
            if (values[i] is '*' or '+')
            {
                Offset offset = new Offset
                {
                    Start = i,
                    End = i + 1
                };
                for (var k = i + 1; k < values.Length; k++)
                {
                    if (values[k] is not ' ') break;
                    offset.End++;
                }

                var problem = new Problem
                {
                    Operation = values[i] == '+' ? Operation.Add : Operation.Multiply
                };
                problems.Add(problem);
                offsets.Add(offset);
            }
        }


        var numberLineCount = _lines.Count - 1;
        var offsetIndex = 0;
        foreach (var offset in offsets)
        {
            for (int i = offset.Start; i < offset.End; i++)
            {
                string numString = "";
                for (int j = 0; j < numberLineCount; j++)
                {
                    if (IsNumber(_lines[j][i]))
                    {
                        numString += _lines[j][i];
                    }
                }

                if (numString != "")
                {
                    problems[offsetIndex].AddNumber(int.Parse(numString));
                }
            }

            offsetIndex++;
        }

        return problems;
    }
}