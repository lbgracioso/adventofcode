using AdventOfCode.Utils;

namespace AdventOfCode.Advent2022;

public class Day5 : IPuzzle
{
    public Day5()
    {
        Configure();
    }
    
    private List<( int, Stack<string> )> _cratesPuzzle1 = new();
    private List<( int, Stack<string> )> _cratesPuzzle2 = new();

    private record Command(int Move, int From, int To);

    private List<Command> _formattedCommands = new();
    
    public void Configure()
    {
        string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split("/bin/").First();
        string[] filedata = File.ReadAllLines(projectPath + "/Advent2022/Data/day5.txt").ToArray();

        _cratesPuzzle1 = SeparateCrates(filedata);
        _cratesPuzzle2 = SeparateCrates(filedata);

        string[] commands = filedata[(Array.IndexOf(filedata, "") + 1)..];

        _formattedCommands = commands
            .Select(c => new Command(int.Parse(c[5..7]), int.Parse(c[12..14]), int.Parse(c[17..]))).ToList();
    }

    private List<( int, Stack<string> )> SeparateCrates(string[] filedata)
    {
        List<( int, Stack<string> )> _formattedCrates = new();
        List<string> crates = new();

        foreach (string line in filedata)
        {
            if (string.IsNullOrEmpty(line))
                break;

            crates.Add(line);
        }

        List<int> numberPositions = new();

        for (int i = 0; i < crates[^1].Length; i++)
        {
            numberPositions.Add(crates[^1].IndexOf(i.ToString(), StringComparison.Ordinal));
        }

        numberPositions.RemoveAll(x => x == -1);

        foreach (var numberPosition in numberPositions)
        {
            List<string> crateNames = new();
            Stack<string> cratesStack = new();

            crates.ForEach(x => crateNames.Add(x[numberPosition].ToString()));
            crateNames.RemoveAll(x => int.TryParse(x, out _));
            crateNames.RemoveAll(string.IsNullOrWhiteSpace);
            crateNames.Reverse();
            crateNames.ForEach(c => cratesStack.Push(c));
            _formattedCrates.Add((int.Parse(crates[^1][numberPosition].ToString()), cratesStack));
        }

        return _formattedCrates;
    }

    public string RunFirstPuzzle()
    {
        foreach (var command in _formattedCommands)
        {
            int indexFrom = _cratesPuzzle1.FindIndex(c => c.Item1 == command.From);
            int indexTo = _cratesPuzzle1.FindIndex(c => c.Item1 == command.To);
            
            Enumerable.Range(0, command.Move).ToList()
                .ForEach(_ => _cratesPuzzle1[indexTo].Item2.Push(_cratesPuzzle1[indexFrom].Item2.Pop()) );
        }

        return $"After the rearrangement procedure completes, the crate {_cratesPuzzle1.Aggregate(string.Empty, (topCrates, currentStack) => topCrates + currentStack.Item2.Peek())} ends up on top of each stack.";
    }

    public string RunSecondPuzzle()
    {
        
        foreach (var command in _formattedCommands)
        {
            int indexFrom = _cratesPuzzle2.FindIndex(c => c.Item1 == command.From);
            int indexTo = _cratesPuzzle2.FindIndex(c => c.Item1 == command.To);
            
            Enumerable.Range(0, command.Move).ToList()
                .Select(_ => _cratesPuzzle2[indexFrom].Item2.Pop()).Reverse().ToList().ForEach(c => _cratesPuzzle2[indexTo].Item2.Push(c));
        }

        return $"After the rearrangement procedure completes, the crate {_cratesPuzzle2.Aggregate(string.Empty, (topCrates, currentStack) => topCrates + currentStack.Item2.Peek())} ends up on top of each stack.";
    }
    
}