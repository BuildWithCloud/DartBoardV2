namespace DartBoardV2;

public class Player
{
    public string Name;
    private List<Turn> Turns = new List<Turn>();
    public Player(string name)
    {
        Name = name;
    }
    public void AddTurn(Turn turn)
    {
        Turns.Add(turn);
    }
    public int GetScore()
    {
        int score = 0;
        foreach (var turn in Turns)
        {
            foreach(var @throw in turn.Throws)
            {
                score += @throw.GetScore();
            }
        }
        return score;
    }
}