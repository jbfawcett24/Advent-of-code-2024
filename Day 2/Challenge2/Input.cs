using Microsoft.Win32.SafeHandles;

class Input
{
    List<string> input = File.ReadAllLines("input.txt").ToList();
    List<List<string>> splitInput = new List<List<string>>{};
    List<int> currentLine = new List<int>{};
    int numSafe = 0;
    List<bool> safe;
    public Input()
    {
        for(int i = 0; i< input.Count; i++)
        {
            string[] currentLine = input[i].Split(" ");
            splitInput.Add(currentLine.ToList());
        }
        safe = new List<bool>(new bool[splitInput.Count]);
    }
    public void CheckSafe()
    {
        //bool isSafe = false;
        for(int i = 0; i<splitInput.Count; i++)
        {
            SetCurrentLine(i);
            bool safeUp = CheckOrderUp(currentLine);
            bool safeDown = CheckOrderDown(currentLine);
            bool safeSpace = CheckSpace(currentLine);
            if((safeUp == true || safeDown == true) && safeSpace == true)
            {
                //isSafe = true;
                safe[i] = true;
                //Console.WriteLine("safe");
            } else {
                CheckReplaced(i);
            }
        }
        Console.WriteLine(AddSafe());
    }
    private void CheckReplaced(int index)
    {
        bool safeUp = false;
        bool safeDown = false;
        bool safeSpace = false;
        //bool isSafe = false;
        for(int i = 0; i<currentLine.Count; i++)
        {
            SetCurrentLine(index);
            //currentLine.RemoveAt(i);
            List<int> tempLine = new List<int>(currentLine);
            tempLine.RemoveAt(i);
            // for(int j = 0; j<currentLine.Count; j++)
            // {
            //     Console.WriteLine(currentLine[j]);
            // }
            safeUp = CheckOrderUp(tempLine);
            safeDown = CheckOrderDown(tempLine);
            safeSpace = CheckSpace(tempLine);
            if((safeUp == true || safeDown == true) && safeSpace == true)
            {
                //Console.WriteLine(i);
                safe[index] = true;
                return;
            }
        }
    }
    private void SetCurrentLine(int index)
    {
        currentLine.Clear();
        for(int i = 0; i<splitInput[index].Count; i++)
        {
            currentLine.Add(int.Parse(splitInput[index][i]));
            //Console.WriteLine(currentLine[i]);
        }
    }
    private bool CheckOrderUp(List<int> line)
    {
            for(int i = 1; i<line.Count; i++)
            {
                if(line[i-1]>line[i])
                {
                    //Console.WriteLine("false");
                    return false;
                }
        }
        //Console.WriteLine("true");
        return true;
    }
    private bool CheckOrderDown(List<int> line)
    {
        for(int i = 1; i<line.Count; i++)
            {
                if(line[i-1]<line[i])
                {
                    //Console.WriteLine("false");
                    return false;
                }
        }
        //Console.WriteLine("true");
        return true;
    }
    private bool CheckSpace(List<int> line)
    {
        for(int i = 1; i<line.Count; i++)
        {
            //Console.WriteLine($"{numDown} {numCheck}");
            if(line[i] == line[i-1] || Math.Abs(line[i]-line[i-1])>3)
            {
                //Console.WriteLine("false");
                return false;
            }
        }
        //Console.WriteLine("true");
        return true;
    }
    private int AddSafe()
    {
        for(int i = 0; i<safe.Count; i++)
        {
            if(safe[i] == true)
            {
                numSafe++;
            }
        }
        return numSafe;
    }
}