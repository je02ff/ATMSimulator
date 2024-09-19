using ATMSimulator.Model.objects;

namespace ATMSimulator;

public static class Login
{
    private static string _loginPrompt = "Please enter 6-digit account number: ";

    public static User? LoginUser(User? user)
    {
        var accountNumber = GetAccountNumber();
        var pin = GetPin();
        // Authenticate();
        return DataAccess.GetUser(accountNumber);
    }

    private static int GetAccountNumber()
    {
        int inputRow = UserInterface.OrigRow + 4;
        int inputCol = UserInterface.OrigCol + 2;
        const int maxInputLength = 6;
        bool isValidInput;
        string inputUserAccount;
        do
        {
            ConsoleUtils.WriteAt(new string(' ', UserInterface.BoxWidth - 4), inputCol, inputRow);
            ConsoleUtils.WriteAt(_loginPrompt, inputCol, inputRow);
            Console.SetCursorPosition(inputCol + _loginPrompt.Length, inputRow);
            ConsoleUtils.GetUserInput(maxInputLength, out inputUserAccount);
            ConsoleUtils.WriteAt(new string(' ', 6), inputCol + _loginPrompt.Length, inputRow);
            isValidInput = Validate.IsValidAccountNumber(inputUserAccount);

            if (!isValidInput)
            {
                InvalidText(inputCol, inputRow);
                Thread.Sleep(1000);
            }
        } while (!isValidInput);

        ConsoleUtils.WriteAt(new string(' ', UserInterface.BoxWidth - 4), inputCol, inputRow);

        return int.Parse(inputUserAccount);
    }

    private static int GetPin()
    {

        return 4444;
    }
    
    private static void InvalidText(int inputCol, int inputRow)
    {
        string outputText = "Invalid account number.";
        Console.ForegroundColor = ConsoleColor.DarkRed;
        ConsoleUtils.WriteAt(outputText, _loginPrompt.Length + inputCol, inputRow);
        Console.ResetColor();
    }
}