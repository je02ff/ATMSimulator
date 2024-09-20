using ATMSimulator.Factory.Interface;

namespace ATMSimulator.Factory;

class Balance : IOption
{
    public void DisplayOption()
    {
        ConsoleUtils.WriteAt("BALANCE", 10,10);
    }
}