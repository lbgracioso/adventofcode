using AdventOfCode.Utils;

namespace AdventOfCode.Advent2022;

public class Day3 : IPuzzle
{
    public Day3()
    {
        Configure();
    }

    private readonly List<(string, string)> _formattedRucksacks = new();
    private readonly List<string> _rucksacks = new();
    
    public void Configure()
    {
        string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split("/bin/").First();
        string[] filedata = File.ReadAllLines(projectPath + "/Advent2022/Data/day3.txt").ToArray();

        foreach (var compartment in filedata)
        {
            var firstHalf = compartment[..(compartment.Length / 2)];
            var secondHalf = compartment[(compartment.Length / 2)..];
            _formattedRucksacks.Add( (firstHalf, secondHalf) );
            _rucksacks.Add(compartment);
        }
    }

    public string RunFirstPuzzle()
    {
        int sum = 0;
        
        foreach (var compartments in _formattedRucksacks)
        {
            List<char> commonItems = compartments.Item1.Intersect(compartments.Item2).ToList();
            sum += SumPriorities(commonItems);
        }

        return $"The sum of priorities is {sum}";
    }

    public string RunSecondPuzzle()
    {
        int sum = 0;

        for (var i = 0; i < _rucksacks.Count; i += 3)
        {
            List<string> group = _rucksacks.GetRange(i, 3);
            List<char> commonItems = group[0].Intersect(group[1]).Intersect(group[2]).ToList();
            sum += SumPriorities(commonItems);
        }
        
        return $"The sum of priorities for all the groups is {sum}";
    }

    private static int SumPriorities(List<char> commonItems)
    {
        int sum = 0;
        commonItems.ForEach(x => sum += char.IsLower(x) ? x & 31 : (x & 31) + 26);
        return sum;
    }
}