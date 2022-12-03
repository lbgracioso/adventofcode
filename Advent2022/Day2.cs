using AdventOfCode.Utils;

namespace AdventOfCode.Advent2022;

public class Day2: IPuzzle
{
    public Day2()
    {
        Configure();
    }

    private readonly Dictionary<Moves, int> _movePoints = new()
    {
        {Moves.Rock, 1},
        {Moves.Paper, 2},
        {Moves.Scissors, 3}
    };

    private readonly Dictionary<Moves, (Moves canWinOf, Moves canLoseTo)> _possibilities = new()
    {
        [Moves.Paper] = (Moves.Rock, Moves.Scissors),
        [Moves.Rock] = (Moves.Scissors, Moves.Paper),
        [Moves.Scissors] = (Moves.Paper, Moves.Rock)
    };

    enum Moves
    {
        Rock,
        Paper,
        Scissors
    }
    
    internal enum End
    {
        Victory,
        Draw,
        Lost
    }
    
    private List<string> _rightSide = new();
    private List<string> _leftSide = new();
    
    public void Configure()
    {
        string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split("/bin/").First();
        string[] filedata = File.ReadAllLines(projectPath + "/Advent2022/Data/day2.txt").ToArray();

        foreach (string match in filedata)
        {
            string[] moves = match.Split(' ');
            _leftSide.Add(moves[0]);
            _rightSide.Add(moves[1]);
        }
    }

    public string RunFirstPuzzle()
    {
        return $"Player total score would be of {CalculatePlayerPoints(_rightSide, _leftSide)}";
    }

    public string RunSecondPuzzle()
    {
        Dictionary<string, End> endings = new()
        {
            {"X", End.Lost},
            {"Y", End.Draw},
            {"Z", End.Victory},
        };
        
        Dictionary<string, Moves> moveNames = new()
        {
            {"A", Moves.Rock},
            {"B", Moves.Paper},
            {"C", Moves.Scissors}
        };
        
        Dictionary<Moves, string > moveIdentifiers = new()
        {
            {Moves.Rock, "A"},
            {Moves.Paper, "B"},
            {Moves.Scissors, "C"}
        };

        List<String> playerData = _rightSide;
        
        foreach (var opponentMove in _leftSide.Select((identifier, index) => (identifier, index)))
        {
            End expectedEndFormatted = endings[_rightSide[opponentMove.index]];
            Moves opponentMoveFormatted =  moveNames[opponentMove.identifier];

            if (expectedEndFormatted == End.Draw)
                playerData[opponentMove.index] = opponentMove.identifier;
            else if (expectedEndFormatted == End.Victory)
            {
                (Moves, Moves) possibility = _possibilities[opponentMoveFormatted];
                playerData[opponentMove.index] = moveIdentifiers[possibility.Item2];
            }
            else if (expectedEndFormatted == End.Lost)
            {
                (Moves, Moves) possibility = _possibilities[opponentMoveFormatted];
                playerData[opponentMove.index] = moveIdentifiers[possibility.Item1];
            }
        }

        return $"Player total score would be of {CalculatePlayerPoints(playerData, _leftSide)}";
    }

    private int CalculatePlayerPoints(List<string> playerData, List<string> opponentData)
    {
        Dictionary<string, Moves> moveNames = new()
        {
            {"A", Moves.Rock},
            {"B", Moves.Paper},
            {"C", Moves.Scissors},
            {"X", Moves.Rock},
            {"Y", Moves.Paper},
            {"Z", Moves.Scissors},
        };
        
        int wins = 0;
        int draws = 0;
        int loses = 0;
        
        foreach (var playerMove in playerData.Select((identifier, index) => (identifier, index)))
        {
            Moves opponentMoveFormatted = moveNames[opponentData[playerMove.index]];
            Moves playerMoveFormatted =  moveNames[playerMove.identifier];
            
            if ( playerMoveFormatted == opponentMoveFormatted )
                draws += _movePoints[playerMoveFormatted] + 3;
            else
            {
                (Moves, Moves) possibility = _possibilities[playerMoveFormatted];
                
                if (opponentMoveFormatted == possibility.Item1)
                    wins += (6 + _movePoints[playerMoveFormatted]);
                else
                    loses += _movePoints[playerMoveFormatted];
            }
        }

        return wins + draws + loses;

    }
}