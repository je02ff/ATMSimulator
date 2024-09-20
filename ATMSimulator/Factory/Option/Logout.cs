using ATMSimulator.Factory.Interface;

namespace ATMSimulator.Factory.Option;

class Logout : IOption
{
    public void DisplayOption()
    {
        ConsoleUtils.WriteAt("LOGOUT", 10,10);
    }
}