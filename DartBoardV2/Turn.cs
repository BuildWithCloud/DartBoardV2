namespace DartBoardV2;

public class Turn
{
    private int NumOfThrows;
    public Throw[] Throws;
    
    public Turn(int numOfThrows)
    {
        NumOfThrows = numOfThrows;
        Throws = new Throw[numOfThrows];
    }
    public Turn()
    {
        NumOfThrows = 3;
        Throws = new Throw[3];
    }
    
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
}