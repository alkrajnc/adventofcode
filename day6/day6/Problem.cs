namespace day6;

public class Problem()
{
    private Operation _operation; 
    private List<int> _numbers = [];
    private List<string> _unparsedNumbers = [];

    public Operation Operation {get => _operation; set => _operation = value; }


    public List<int> Numbers => _numbers;
    

    public void AddNumber(int number)
    {
        _numbers.Add(number);
    }

    private void parse()
    {
        var len = 0;
        for (var i = 0; i < len; i++)
        {
            
        }
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