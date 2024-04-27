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
    public int GetScore()
    {
        return Score * (int)Multiplier;
    }

    public override string ToString()
    {
        string output = "";
        switch (Multiplier)
        {
            case Multiplier.Miss:
                output += "M";
                return output;
                break;
            case Multiplier.Single:
                output += "";
                break;
            case Multiplier.Double:
                output += "D ";
                break;
            case Multiplier.Triple:
                output += "T";
                break;
        }
        output += Score.ToString();
        return output;
    }
}
