using System;
using System.Text.RegularExpressions;
using System.Xml;

class Program
{
    public static int Mult(int num1, int num2)
    {
        return num1*num2;
    }
    public static int GetNumbers(Match input, bool enable)
    {
        Regex numRegex = new Regex(@"\d{1,3}");
        MatchCollection numbers = numRegex.Matches(input.Value);
        if(enable == true)
        {
            return Mult(int.Parse(numbers[0].Value), int.Parse(numbers[1].Value));
        }
        return 0;
    }
    static void Main(string[] args)
    {
        string filename = "input.txt";
        string input = File.ReadAllText(filename);
        Regex regex = new Regex(@"(do\(\)|don\'t\(\)|mul\(\d{1,3},\s*\d{1,3}\))");
        MatchCollection matches = regex.Matches(input);
        int output = 0;
        bool enabled = true;
        foreach(Match match in matches)
        {
            if(match.Value.Substring(0,3) == "do(")
            {
                enabled = true;
            } else if(match.Value.Substring(0,3) == "don")
            {
                enabled = false;
            } else if(match.Value.Substring(0,3) == "mul")
            {
                output += GetNumbers(match, enabled);
            }
        }
        Console.WriteLine(output);
    }
}