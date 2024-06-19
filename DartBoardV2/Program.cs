namespace DartBoardV2;

class Program
{
    static void Main()
    {
        StartGame();
    }

    private static int GetNumOfPlayers()
    {
        Console.WriteLine("How many players?");
        return int.Parse(Console.ReadLine() ?? string.Empty);
    }

    private static void StartGame()
    {
        int numPlayers = GetNumOfPlayers();
        List<Player> playerList = new List<Player>();
        for (int i = 0; i < numPlayers; i++)
        {
            Console.WriteLine("Enter player name");
            string name = Console.ReadLine();
            playerList.Add(new Player(name));
        }
        Game game = new Game(playerList.ToArray());
        game.Play();
    }
}