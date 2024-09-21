namespace ATMSimulator;

public class Validate
{
    public static bool IsValidAccountNumber(string accountNumber)
    {
        if (accountNumber.Length != 6 || !int.TryParse(accountNumber, out _))
        {
            return false; 
        }

        return true;
    }

    public static bool IsPinValid(int accountNumber, string pin)
    {
        
        return true;
    }
}