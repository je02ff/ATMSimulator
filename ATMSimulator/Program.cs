using System.Runtime.InteropServices;
using ATMSimulator.Factory;
using ATMSimulator.Model.objects;

namespace ATMSimulator;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        UserInterface.Start();

        // User? user = null;
        // while (user == null)
        // {
        //     user = Login.LoginUser(user);
        // }

        MainMenu(new User()); //TODO plug back in user later
    }

    private static void MainMenu(User user)
    {
        UserInterface.DrawOptions();


        while (true)
        {
            var selectedChoice = ConsoleUtils.GetUserInput(1);
            // selectedChoice = gatherInput
            switch (selectedChoice)
            {
                case "1":
                    //balance
                    LoadOption(new BalanceFactory());
                    break;
                case "2":
                    //Withdraw
                    LoadOption(new WithdrawFactory());
                    break;
                case "3":
                    //Transfer
                    LoadOption(new TransferFactory());
                    break;
                case "4":
                    //Fast Cash
                    LoadOption(new FastCashFactory());
                    break;
                case "5":
                    //Transactions
                    LoadOption(new TransactionsFactory());
                    break;
                case "6":
                    //Logout
                    LoadOption(new LogoutFactory());
                    break;
            }
        }
    }

    private static void LoadOption(OptionFactory optionFactory)
    {
        optionFactory
            .BuildOption()
            .DisplayOption();
    }
}