namespace DartBoardV2;

class Program
{
    static void Main()
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

    private static int GetNumOfPlayers()
    {
        Console.WriteLine("How many players?");
        return int.Parse(Console.ReadLine() ?? string.Empty);
    }
}