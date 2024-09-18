namespace ATMSimulator;

public class Login
{
    private static string _loginPrompt = "Please enter 6-digit account number: ";

    public void LoginUser()
    {
        GetUserAccountNumber();
        // GetUserPin();
        // AuthenticateUser();
    }

    private void GetUserAccountNumber()
    {
        int inputRow = UserInterface.OrigRow + 4;
        int inputCol = UserInterface.OrigCol + 2;
        const int maxInputLength = 6;
        bool isValidInput;

        do
        {
            ConsoleUtils.WriteAt(new string(' ', UserInterface.BoxWidth - 4), inputCol, inputRow);
            ConsoleUtils.WriteAt(_loginPrompt, inputCol, inputRow);
            Console.SetCursorPosition(inputCol + _loginPrompt.Length, inputRow);
            var inputUserAccount = ConsoleUtils.GetUserInput(maxInputLength);
            ConsoleUtils.WriteAt(new string(' ', 6), inputCol + _loginPrompt.Length, inputRow);
            isValidInput = Validate.IsValidAccountNumber(inputUserAccount);

            if (!isValidInput)
            {
                InvalidText();
                Thread.Sleep(1000);
            }
        } while (!isValidInput);

        ConsoleUtils.WriteAt(new string(' ', UserInterface.BoxWidth - 4), inputCol, inputRow);
    }

    private static void InvalidText()
    {
        string outputText = "Invalid account number.";
        Console.ForegroundColor = ConsoleColor.DarkRed;
        ConsoleUtils.WriteAt(outputText, _loginPrompt.Length + 2, 4);
        Console.ResetColor();
    }
}