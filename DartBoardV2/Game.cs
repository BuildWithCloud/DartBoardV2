namespace DartBoardV2;

public class Game
{
    private int _currentPlayer;
    private Player[] _players;
    private int _downFrom = 301;
    private const bool MustFinishOnDouble = true;
    
    public Game(Player[] players)
    {
        _currentPlayer = 0;
        _players = players;
    }

    private bool GameContinue()
    {
        if (_players[_currentPlayer].GetScore() < _downFrom)
        {
            return true;
        }
        if (_players[_currentPlayer].GetScore() > _downFrom -1)
        {
            Console.WriteLine("Bust!");
            _players[_currentPlayer].RemoveLastTurn();
            return true;
        }

        if (!MustFinishOnDouble ||  _players[_currentPlayer].GetLastTurn().GetThrow(2).Multiplier != Multiplier.Double)
        {
            Console.WriteLine("Last throw was not a double, you must finish on a double");
            _players[_currentPlayer].RemoveLastTurn();
            return true;
        }

        return false;
    }

    public void Play ()
    {
        // Before Game
        FrontEnd.Instructions();
        Console.ReadLine();
        
        // During Game
        do
        {
            Console.Clear();
            DisplayGameDetails();
            Turn currentTurn = new Turn();
            for (int i = 0; i < 3; i++)
            {
                currentTurn.Throws[i] = FrontEnd.GetThrow();
            }
            _players[_currentPlayer].AddTurn(currentTurn);
            _currentPlayer = (_currentPlayer + 1) % _players.Length;
        }while(GameContinue());
        
        // After Game
        Console.WriteLine("Do you want to export the data? (y/n)");
        if (Console.ReadLine() == "y")
        {
            foreach (var player in _players)
            {
                player.ExportData();
            }
        }
    }

    private void DisplayGameDetails()
    {
        Console.WriteLine("Scores: ");
        foreach (var player in _players)
        {
            Console.WriteLine($"{player.Name}: {_downFrom - player.GetScore()}");
        }
        Console.WriteLine($"Current Player: {_players[_currentPlayer].Name}");
    }
}

