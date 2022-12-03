using System.Reflection;

namespace AdventOfCode.Utils;

public class Runner
{
    private readonly string _year;

    public Runner(string year)
    {
        _year = year;
    }

    public void Run()
    {
        Console.WriteLine($"------ YEAR {_year} ------");
        
        var types = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => type.Namespace != null 
                           && type.Namespace.Contains($"Advent{_year}") 
                           && typeof(IPuzzle).IsAssignableFrom(type) )
            .ToList();

        foreach (var puzzle in types)
        {
            IPuzzle puzzleObject = (IPuzzle) Activator.CreateInstance(puzzle)!;
            Console.WriteLine(puzzle.Name);
            Console.WriteLine($"1st part: {puzzleObject.RunFirstPuzzle()}");
            Console.WriteLine($"2nd part: {puzzleObject.RunSecondPuzzle()}");
            Console.WriteLine();
        }
    }
}