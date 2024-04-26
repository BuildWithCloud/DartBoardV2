namespace DartBoardV2;

public class Turn
{
    private int NumOfThrows;
    private Throw[] Throws;
    
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
}