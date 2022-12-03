using AdventOfCode.Utils;

namespace AdventOfCode.Advent2022;

public class Day1 : IPuzzle
{
    private List<int> _data = new();

    public Day1()
    {
        Configure();
    }

    public void Configure()
    {
        string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split("/bin/").First();
        string[] filedata = File.ReadAllLines(projectPath + "/Advent2022/Data/day1.txt").ToArray();

        int currentElf = 0;
        foreach (string calories in filedata)
        {
            if (calories != "")
                currentElf += Convert.ToInt32(calories);
            else
            {
                _data.Add(currentElf);
                currentElf = 0;
            }
        }
    }

    public string RunFirstPuzzle()
    {
        int mostCalories = 0;
        _data.ForEach(x => mostCalories = x > mostCalories ? x : mostCalories);
        return $"The elf with most calories carries {mostCalories} calories.";
    }

    public string RunSecondPuzzle()
    {
        var data =_data.OrderBy(num => num).Reverse().ToArray();
        int sum = data[0] + data[1] + data[2];
        return $"The sum of the calories from the top 3 elves is {sum}.";
    }
    
}