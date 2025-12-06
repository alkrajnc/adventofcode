namespace day6;

public class Problem()
{
    private Operation _operation; List<int> _numbers = [];

    public Operation Operation {get => _operation; set => _operation = value; }


    public List<int> Numbers => _numbers;

    public void AddNumber(int number)
    {
        _numbers.Add(number);
    }
    
    
    public long Solve()
    {
        var total = 0L;

        if (_operation == Operation.Multiply)
        {
            total++;
        }

        foreach (var number in _numbers)
        {
            if (_operation == Operation.Add)
            {
                total += number;
            }
            else
            {
                total*=number;
            }
        }
        return total;
    }



    
    
    

}