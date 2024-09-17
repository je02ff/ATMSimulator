using System.Runtime.InteropServices;

namespace ATMSimulator;

class Program
{
    static void Main(string[] args)
    {
        // string atmTitle = "ATMM®2";
        // string defaultMessage = "\nPlease enter a valid 6-digit account number";
        // string pinRequest = "\nEnter 4-digit PIN";
        // string userAccountNumber;
        // string userPin;

        // string userInput;
        
        // Console.Clear();
        // UserInterface.PrintTitle();
        // do
        // {
        //     userInput =Menu.LoginPrompt();
        //
        // } while (!Validate.IsValidAccountNumber(userInput));
        
        // Console.WriteLine(pinRequest);
        

        [DllImport("libc")]
        static extern int system(string exec);


        system(@"printf '\e[8;35;100t'"); //adjust the 50 and 100t for whatever size you are wanting.
        system(@"printf '\e[3;0;0t'"); // moves terminal to top left
     
        Console.Clear();
        var userInterface = new UserInterface();
        
        userInterface.DisplayUi();
    }
}