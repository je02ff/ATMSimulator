using System.Text;

namespace ATMSimulator;

public abstract class ConsoleUtils
{
    public static void WriteAt(string s, int x, int y)
    {
        try
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }
    }

    public static void GetUserInput(int maxLength, out string accountNumber)
    {
        StringBuilder sb = new StringBuilder();

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.Beep();
                break;
            }

            sb.Append(keyInfo.KeyChar);
            if (sb.Length >= maxLength)
            {
                Console.Beep();
                break;
            }
        }

        accountNumber = sb.ToString();
    }
}