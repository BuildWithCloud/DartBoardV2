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
    public void RemoveLastTurn()
    {
        Turns.RemoveAt(Turns.Count - 1);
    }

    public Turn GetLastTurn()
    {
        return Turns[^1];
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
    public void ExportData() // export the turns as a CSV, it adds it on the end of the previous results
    {
        var output = "";
        var path = $@"C:\Users\Joe Bishop\Documents\02 - Home\02 - Areas\Darts\{Name}";
        try
        {
            var streamReader = new StreamReader(path);
            output = streamReader.ReadToEnd();
        }
        catch (FileNotFoundException)
        {
        }

        output += $"GameTime:, {DateTimeOffset.UtcNow.ToUnixTimeSeconds()}\n";
            
        foreach (var turn in Turns)
        {
            output += turn.ToCSV() + "\n";
        }
        
        var streamWriter = new StreamWriter(path);
        streamWriter.Write(output);
        streamWriter.Close();
    }
}