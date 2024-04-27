namespace DartBoardV2;

public class Turn
{
    public List<Throw> Throws = new List<Throw>();
    
    public string ToCSV()
    {
        string output = "";
        foreach (var @throw in Throws)
        {
            output += @throw.ToString() + ",";
        }
        return output;
    }
    
    public Throw GetThrow(int throwNum)
    {
        return Throws[throwNum];
    }
    public Multiplier GetLastMultiplier()
    {
        return Throws[^1].Multiplier;
    }
    public int GetScore()
    {
        int score = 0;
        foreach (var @throw in Throws)
        {
            score += @throw.GetScore();
        }
        return score;
    }
}