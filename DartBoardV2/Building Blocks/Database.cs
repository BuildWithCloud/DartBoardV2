namespace DartBoardV2;

public static class Database
{
    public static List<Throw> GetAllThrows(string name)
    {
        var path = $@"C:\Users\Joe Bishop\Documents\02 - Home\02 - Areas\Darts\{name}.csv";
        var streamReader = new StreamReader(path);
        var throws = new List<Throw>();
        while (streamReader.ReadLine() is { } line)
        {
            if(!line.Contains("GameTime"))
            {
                var throwStrings = line.Split(",");
                throwStrings = throwStrings[0..^1];
                foreach (var throwString in throwStrings)
                {
                    var modifiableThrowString = throwString;
                    Throw throwInput = new Throw(0, Multiplier.Single);

                    // Miss
                    if (modifiableThrowString == "M" || modifiableThrowString == "m")
                    {
                        throwInput.Score = 0;
                        throwInput.Multiplier = Multiplier.Miss;
                        throws.Add(throwInput);
                        break;
                    }

                    // Determine Multiplier
                    if (modifiableThrowString[0] == 'D')
                    {
                        throwInput.Multiplier = Multiplier.Double;
                        modifiableThrowString = modifiableThrowString.Substring(1);
                    }
                    else if (modifiableThrowString[0] == 'T')
                    {
                        throwInput.Multiplier = Multiplier.Triple;
                        modifiableThrowString = modifiableThrowString.Substring(1);
                    }
                    else
                    {
                        throwInput.Multiplier = Multiplier.Single;
                    }

                    // Determine Score
                    throwInput.Score = int.Parse(modifiableThrowString);

                    throws.Add(throwInput);
                }
                
            }
        }

        return throws;

    }    
}