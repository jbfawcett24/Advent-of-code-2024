class Input
{
    private List<string> input = File.ReadAllLines("input.txt").ToList();
    private List<int> splitInput = new List<int>{};
    public List<int> list1 = new List<int>{};
    public List<int> list2 = new List<int>{};
    public Input()
    {
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
    }
    public int SimilarityScore()
    {
        int similarityScore = 0;
        int numEqual;
        for(int i = 0; i<list1.Count; i++){
            numEqual = 0;
            for(int j = 0; j < list2.Count; j++)
            {
                if(list1[i] == list2[j]){
                    numEqual++;
                }
            }
            similarityScore+= list1[i]*numEqual;
        }
        return similarityScore;
    }
}