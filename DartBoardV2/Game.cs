namespace DartBoardV2;

public class Game(Player[] players)
{
    private int _currentPlayer = 0;

    private static bool GameContinue()
    {
        return true;
    }

    public void Play ()
    {
        FrontEnd.Instructions();
        while (GameContinue())
        {
            DisplayGameDetails();
            Turn currentTurn = new Turn();
            for (int i = 0; i < 3; i++)
            {
                currentTurn.Throws[i] = FrontEnd.GetThrow();
            }
            players[_currentPlayer].AddTurn(currentTurn);
            _currentPlayer = (_currentPlayer + 1) % players.Length;
        }
    }

    private void DisplayGameDetails()
    {
        Console.WriteLine($"Current Player {players[_currentPlayer].Name}");
        Console.WriteLine($"Current Score {players[_currentPlayer].GetScore()}");
    }
}

