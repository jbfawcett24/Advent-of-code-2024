using System.Security.Cryptography.X509Certificates;

class Grid
{
    List<List<string>> grid = new List<List<string>>();
    int numWords = 0;

    public Grid()
    {
        string[] input = File.ReadAllLines("input.txt");
        
        for (int i = 0; i < input.Length; i++)
        {
            // Create a new row for each line
            grid.Add(new List<string>());
            
            for (int j = 0; j < input[i].Length; j++)
            {
                // Add each character as a string
                grid[i].Add(input[i][j].ToString());
                //Console.Write(grid[i][j]);
            }
            //Console.WriteLine();
        }
    }
    private void CheckCross(int x, int y)
    {
        string word1 = "A";
        string word2 = "A";
        try
        {
            word1 += grid[y+1][x-1];
            word1 += grid[y-1][x+1];
            word2 += grid[y+1][x+1];
            word2 += grid[y-1][x-1];
        } catch
        {
            //Console.WriteLine("error");
            return;
        }

        if((word1 == "AMS" || word1 == "ASM") && (word2 == "AMS" || word2 == "ASM"))
        {
            //Console.WriteLine($"{word1}, {word2}");
            numWords++;
        }
    }
    public void FindWords()
    {
        for(int i = 0; i<grid.Count; i++)
        {
            for(int j = 0; j<grid[i].Count; j++)
            {
                if(grid[i][j] == "A")
                {
                    CheckCross(j, i);
                }
            }
        }
        Console.WriteLine(numWords);
    }
}
