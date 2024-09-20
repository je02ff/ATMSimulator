using ATMSimulator.Factory.Interface;

namespace ATMSimulator.Factory.Option;

class Withdraw : IOption
{
    public void DisplayOption()
    {
        ConsoleUtils.WriteAt("WIthDRAW", 10,10);
    }
}