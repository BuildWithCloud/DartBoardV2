namespace DartBoardV2;

public class Throw
{
    public Multiplier Multiplier;
    public int Score;
    public Throw(int score, Multiplier multiplier)
    {
        Score = score;
        Multiplier = multiplier;
    }
    public int GetThrowScore()
    {
        return Score * (int)Multiplier;
    }
}
