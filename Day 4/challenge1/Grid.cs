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
                Console.Write(grid[i][j]);
            }
            Console.WriteLine();
        }
        CheckDirection(1,0, 1, 1);
    }
    private void CheckDirection(int x, int y, int dx, int dy)
    {
        string word = "";
        try
        {
            for (int i = 0; i < 4; i++)
            {
                int newX = x + i * dx;
                int newY = y + i * dy;
                word += grid[newY][newX];
            }
        } catch
        {
            return;
        }

        if(word == "XMAS")
        {
            numWords++;
            Console.WriteLine($"{word} ({x}, {y}) {dx}, {dy}");
        }
    }
    public void FindWords()
    {
        for(int i = 0; i<grid.Count; i++)
        {
            for(int j = 0; j<grid[i].Count; j++)
            {
                if(grid[i][j] == "X")
                {
                    CheckDirection(j, i, 1, 0);
                    CheckDirection(j, i, 0, 1);
                    CheckDirection(j, i, 1, 1);
                    CheckDirection(j, i, -1, 0);
                    CheckDirection(j, i, 0, -1);
                    CheckDirection(j, i, 1, -1);
                    CheckDirection(j, i, -1, 1);
                    CheckDirection(j, i, -1, -1);
                }
            }
        }
        Console.WriteLine(numWords);
    }
}
