using ATMSimulator.Factory.Interface;

namespace ATMSimulator.Factory.Option;

class Transfer : IOption
{
    public void DisplayOption()
    {
        ConsoleUtils.WriteAt("TRansFER", 10,10);
    }
}