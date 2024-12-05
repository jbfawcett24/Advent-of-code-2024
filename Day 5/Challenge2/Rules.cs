class Rules
{
    List<string> rules = File.ReadAllLines("inputTest.txt").ToList();
    List<List<string>> pages = new List<List<string>>{};
    List<int> truePages = new List<int>{};
    int output = 0;
    public Rules()
    {
        int index = rules.FindIndex(line => string.IsNullOrWhiteSpace(line));
        for(int i = 0; i<rules.Count-(index+1); i++)
        {
            pages.Add(rules[i+(index+1)].Split(",").ToList());
        }
        rules.RemoveRange(index, rules.Count()-index);
    }
    public void CheckPages()
    {
        bool isCorrect = false;
            for(int i = 0; i<pages.Count; i++)
            {
                string [] currentRule = [];   
                isCorrect = true; 
                for(int ruleNum = 0; ruleNum<rules.Count; ruleNum++)
                {
                    currentRule = rules[ruleNum].Split("|");
                    //Console.WriteLine($"{currentRule[0]} {currentRule[1]}");
                    int page1 = pages[i].IndexOf(currentRule[0]);
                    int page2 = pages[i].IndexOf(currentRule[1]);
                    if(page1>page2 && page1>=0 && page2>=0)
                    {
                        isCorrect = false;
                    }
                    //Console.WriteLine($"{page1} {page2}");
                }
                if(isCorrect == false)
                {
                    truePages.Add(i);
                    //Console.WriteLine("true");
                }
            }
    }
    public int AddNumbers()
    {
        int output = 0;
        for(int i = 0; i<truePages.Count; i++)
        {
            int index = truePages[i];
            output+=int.Parse(pages[index][pages[index].Count/2]);
        }
        return output;
    }
    public void changePages()
    {
        for(int i = 0; i<truePages.Count; i++)
            {
            string [] currentRule = [];  
            for(int ruleNum = 0; ruleNum<rules.Count; ruleNum++)
            {
                for(int newPos = 0; newPos<pages[truePages[i]].Count; newPos++)
                {
                    for(int currentPos = 0; currentPos<pages[truePages[i]].Count; currentPos++)
                    {
                        List<string> currentLine = NewLine(pages[truePages[i]], 0, newPos);
                        currentRule = rules[ruleNum].Split("|");
                        //Console.WriteLine($"{currentRule[0]} {currentRule[1]}");
                        int page1 = currentLine.IndexOf(currentRule[0]);
                        int page2 = currentLine.IndexOf(currentRule[1]);
                        if(page1<page2 && page1>=0 && page2>=0)
                        {
                            output+=int.Parse(currentLine[currentLine.Count/2]);
                            return;
                        }
                    }
                }
                //Console.WriteLine($"{page1} {page2}");
            }
        }
    }
    private List<string> NewLine(List<string> line, int currentPos, int newPos)
    {
        string number = line[currentPos];
        line.RemoveAt(currentPos);
        line.Insert(newPos, number);
        return line;
    }
    public int GetOutput()
    {
        return output;
    }
}