using System;
using System.Text.RegularExpressions;

class Program
{
    public static int Mult(int num1, int num2)
    {
        return num1*num2;
    }
    static void Main(string[] args)
    {
        string filename = "input.txt";
        string input = File.ReadAllText(filename);
        Regex regex = new Regex(@"mul\(\d{1,3},\d{1,3}\)");
        MatchCollection matches = regex.Matches(input);
        List<int> numbers = new List<int>{};
        List<int> multipliedNumbers = new List<int>{};
        int output = 0;

        foreach (Match match in matches)
        {
            Regex numRegex = new Regex(@"\d{1,3}");
            MatchCollection Regnumbers = numRegex.Matches(match.ToString());
            foreach(Match numMatch in Regnumbers)
            {
                numbers.Add(int.Parse(numMatch.Value));

            }
        }
        for(int i = 1; i<numbers.Count; i+=2)
        {
            multipliedNumbers.Add(Mult(numbers[i], numbers[i-1]));
        }
        for(int i = 0; i<multipliedNumbers.Count; i++)
        {
            output += multipliedNumbers[i];
        }
        Console.WriteLine(output);
    }
}