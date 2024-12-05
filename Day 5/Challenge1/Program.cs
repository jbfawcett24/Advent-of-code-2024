using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Rules rules = new Rules();
        rules.CheckPages();
        Console.WriteLine(rules.AddNumbers());
    }
}