using System;

class Program
{
    static void Main(string[] args)
    {
        List<string> input = File.ReadAllLines("input.txt").ToList();
        List<int> splitInput = new List<int>{};
        List<int> list1 = new List<int>{};
        List<int> list2 = new List<int>{};
        List<int> difference = new List<int>{};
        int output = 0;

        for(int i = 0; i< input.Count; i++)
        {
            string[] currentInput = input[i].Split("   ");
            splitInput.Add(int.Parse(currentInput[0]));
            splitInput.Add(int.Parse(currentInput[1]));
        }
        for(int i = 0; i < splitInput.Count; i+=2)
        {
            list1.Add(splitInput[i]);
            list2.Add(splitInput[i+1]);
        }
        list1.Sort();
        list2.Sort();
        for(int i = 0; i<list1.Count; i++)
        {
            difference.Add(Math.Abs(list1[i]-list2[i]));
        }
        for(int i = 0; i<difference.Count; i++){
            output += difference[i];
        }
        Console.WriteLine(output);
    }
}