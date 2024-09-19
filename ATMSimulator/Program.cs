using System.Runtime.InteropServices;
using ATMSimulator.Model.objects;

namespace ATMSimulator;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        UserInterface.Start();

        User? user = null;
        while (user == null)
        {
            user = Login.LoginUser(user);
        }
        
        MainMenu(user);
    }

    private static void MainMenu(User user)
    {
        UserInterface.DrawOptions();

        int selectedChoice = 0;
        while (selectedChoice != 6)
        {
            //todo get input choice
            // selectedChoice = gatherInput
            switch (selectedChoice)
            {
                case 1:
                    //balance
                    break;
                case 2:
                    //Withdraw
                    break;
                case 3:
                    //Transfer
                    break;
                case 4:
                    //Fast Cash
                    break;
                case 5:
                    //Transactions
                    break;
                case 6:
                    //Logout
                    break;
            }
        }
    }
}