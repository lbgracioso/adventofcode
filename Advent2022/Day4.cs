using AdventOfCode.Utils;

namespace AdventOfCode.Advent2022;

public class Day4 : IPuzzle
{
    public Day4()
    {
        Configure();
    }
    
    private List<( (int, int), (int, int) )> _formattedPairs = new();

    public void Configure()
    {
        string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split("/bin/").First();
        string[] filedata = File.ReadAllLines(projectPath + "/Advent2022/Data/day4.txt").ToArray();
            
        foreach (string pairsGroup in filedata)
        {
            string[] pairs = pairsGroup.Split(',');
            List<string> firstPair = pairs[0].Split('-').ToList();
            List<string> secondPair = pairs[1].Split('-').ToList();

            List<int> firstPairFormatted = FormatStringPairToInt(firstPair);
            List<int>  secondPairFormatted = FormatStringPairToInt(secondPair);

            _formattedPairs.Add((
                (firstPairFormatted[0], firstPairFormatted[1]),
                (secondPairFormatted[0], secondPairFormatted[1])
                ));
        }
    }

    private static List<int> FormatStringPairToInt(List<string> secondPair)
    {
        List<int> secondPairFormatted = new();
        secondPair.ForEach(x => secondPairFormatted.Add(Convert.ToInt32(x)));
        return secondPairFormatted;
    }

    public string RunFirstPuzzle()
    {
        int totalPairs = 0;
        
        foreach (var formattedPair in _formattedPairs)
        {
            int[] firstPair = GetPairRange(formattedPair.Item1.Item1, formattedPair.Item1.Item2);
            int[] secondPair = GetPairRange(formattedPair.Item2.Item1, formattedPair.Item2.Item2);

            if (firstPair.All(secondPair.Contains))
                totalPairs++;
            else if (secondPair.All(firstPair.Contains))
                totalPairs++;
        }

        return $"One range fully contains the other in {totalPairs} assignment pairs";
    }

    public string RunSecondPuzzle()
    {
        int totalPairs = 0;
        
        foreach (var formattedPair in _formattedPairs)
        {
            int[] firstPair = GetPairRange(formattedPair.Item1.Item1, formattedPair.Item1.Item2);
            int[] secondPair = GetPairRange(formattedPair.Item2.Item1, formattedPair.Item2.Item2);

            if (firstPair.Any(secondPair.Contains))
                totalPairs++;
        }

        return $"{totalPairs} assignment pairs overlap";
    }
    
    private static int[] GetPairRange(int start, int end) => Enumerable.Range(start, (end - start) + 1).ToArray();

}