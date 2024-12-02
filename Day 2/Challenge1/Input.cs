using Microsoft.Win32.SafeHandles;

class Input
{
    List<string> input = File.ReadAllLines("input.txt").ToList();
    List<List<string>> splitInput = new List<List<string>>{};
    int numSafe = 0;
    public Input()
    {
        for(int i = 0; i< input.Count; i++)
        {
            string[] currentLine = input[i].Split(" ");
            splitInput.Add(currentLine.ToList());
        }
    }
    public void CheckSafe()
    {
        //bool isSafe = false;
        for(int i = 0; i<splitInput.Count; i++)
        {
            //isSafe = false;
            bool safeUp = CheckOrderUp(i);
            bool safeDown = CheckOrderDown(i);
            bool safeSpace = CheckSpace(i);
            if((safeUp == true || safeDown == true) && safeSpace == true)
            {
                //isSafe = true;
                numSafe++;
                //Console.WriteLine("safe");
            } else 
            {
                //isSafe = false;
                //Console.WriteLine("Unsafe");
            }
        }
        Console.WriteLine(numSafe);
    }
    private bool CheckOrderUp(int i)
    {
            int num1;
            int num2;
            for(int j = 1; j<splitInput[i].Count; j++)
            {
                num1 = int.Parse(splitInput[i][j-1]);
                num2 = int.Parse(splitInput[i][j]);
                if(num1>num2)
                {
                    //Console.WriteLine("false");
                    return false;
                }
        }
        //Console.WriteLine("true");
        return true;
    }
    private bool CheckOrderDown(int i)
    {
        int num1;
        int num2;
        for(int j = 1; j<splitInput[i].Count; j++)
            {
                num1 = int.Parse(splitInput[i][j-1]);
                num2 = int.Parse(splitInput[i][j]);
                if(num1<num2)
                {
                    //Console.WriteLine("false");
                    return false;
                }
        }
        //Console.WriteLine("true");
        return true;
    }
    private bool CheckSpace(int i)
    {
        int numDown;
        int numCheck;
        for(int j = 1; j<splitInput[i].Count; j++)
        {
            numDown = int.Parse(splitInput[i][j-1]);
            numCheck = int.Parse(splitInput[i][j]);
            //Console.WriteLine($"{numDown} {numCheck}");
            if(numCheck == numDown || Math.Abs(numCheck-numDown)>3)
            {
                //Console.WriteLine("false");
                return false;
            }
        }
        //Console.WriteLine("true");
        return true;
    }
}