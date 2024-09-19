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
        UserInterface.DrawOptions();
        DataAccess data = new();
        // data.GetUser(accountNumber: 123123);
        while (true)
        {
            
        }
    }
}