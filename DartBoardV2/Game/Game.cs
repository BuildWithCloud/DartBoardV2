namespace DartBoardV2;

public class Game
{
    private int _currentPlayer;
    private readonly Player[] _players;
    private const int DownFrom = 301;
    private const bool MustFinishOnDouble = true;
    
    public Game(Player[] players)
    {
        _currentPlayer = 0;
        _players = players;
    }

    private bool GameContinue()
    {
        if (_players[_currentPlayer].GetScore() < DownFrom -1)
        {
            return true;
        }
        if (_players[_currentPlayer].GetScore() > DownFrom)
        {
            Console.WriteLine("Bust!");
            _players[_currentPlayer].RemoveLastTurn();
            return true;
        }

        if (!MustFinishOnDouble ||  _players[_currentPlayer].GetLastTurn().GetLastMultiplier() != Multiplier.Double)
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
        bool endGame = false;
        // During Game
        while (!endGame)
        {
            Console.Clear();
            DisplayGameDetails();
            _players[_currentPlayer].AddTurn(new Turn());
            for (int i = 0; i < 3; i++)
            {
                _players[_currentPlayer].Turns[^1].Throws.Add(FrontEnd.GetThrow());
                if (!GameContinue())
                {
                    endGame = true;
                    break;
                }
            }
            _currentPlayer = (_currentPlayer + 1) % _players.Length;
        }

        AskAndExportData();
    }

    private void DisplayGameDetails()
    {
        Console.WriteLine("Scores: ");
        foreach (var player in _players)
        {
            Console.WriteLine($"{player.Name}: {DownFrom - player.GetScore()}");
        }
        Console.WriteLine($"Current Player: {_players[_currentPlayer].Name}");
    }

    private void AskAndExportData()
    {
        Console.WriteLine("Do you want to export the data? (y/n)");
        if (Console.ReadLine() == "y")
        {
            foreach (var player in _players)
            {
                try
                {
                    player.ExportData();
                }
                catch
                {
                    Console.WriteLine("It was not possible to export the data. Check that the file is not open in another program.");
                    AskAndExportData();
                }
            }
        }
    }
}

