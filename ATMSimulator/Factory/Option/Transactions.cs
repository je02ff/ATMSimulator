using ATMSimulator.Factory.Interface;

namespace ATMSimulator.Factory.Option;

class Transactions : IOption
{
    public void DisplayOption()
    {
        ConsoleUtils.WriteAt("TRANSaction", 10,10);
    }
}