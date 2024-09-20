using ATMSimulator.Factory.Interface;

namespace ATMSimulator.Factory.Option;

class FastCash : IOption
{
    public void DisplayOption()
    {
        ConsoleUtils.WriteAt("FASTCASH", 10,10);
    }
}