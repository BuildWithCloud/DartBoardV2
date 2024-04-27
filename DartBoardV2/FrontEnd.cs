namespace DartBoardV2;

public static class FrontEnd
{
    public static Throw GetThrow()
    {
        Console.WriteLine("Please enter the score: ");
        try
        {
            string input = Console.ReadLine();
            Throw throwInput = new Throw(0, Multiplier.Single);

            // Miss
            if (input == "m")
            {
                throwInput.Score = 0;
                throwInput.Multiplier = Multiplier.Miss;
                return throwInput;
            }

            // Determine Multiplier
            if (input[0] == 'D')
            {
                throwInput.Multiplier = Multiplier.Double;
                input = input.Substring(1);
            }
            else if (input[0] == 'T')
            {
                throwInput.Multiplier = Multiplier.Triple;
                input = input.Substring(1);
            }
            else
            {
                throwInput.Multiplier = Multiplier.Single;
            }

            // Determine Score
            throwInput.Score = int.Parse(input);

            return throwInput;
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid input. Please try again.");
            return GetThrow();
        }
    }

    public static void Instructions()
    {
        Console.WriteLine("Inputting the score:");
        Console.WriteLine("D and T mean Double and Triple. For a single, just input the number.");
        Console.WriteLine("For example, 20 means Single 20, D20 means Double 20, T20 means Triple 20.");
        Console.WriteLine("for bull and outer bull, input 25 and D25.");
        Console.WriteLine("Enter 'm' if you miss.");
        Console.WriteLine("Press Enter to start the game.");
    }
}