using System.Runtime.InteropServices;

namespace ATMSimulator;

class Program
{
    static void Main(string[] args)
    {
        [DllImport("libc")]
        static extern int system(string exec);
        system(@"printf '\e[8;35;100t'"); //adjust terminal window size.
        system(@"printf '\e[3;0;0t'"); // moves terminal to top left
     
        Console.Clear();
        var userInterface = new UserInterface();
        
        userInterface.DisplayUi();
    }
}