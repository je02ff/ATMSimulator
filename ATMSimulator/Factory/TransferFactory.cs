using ATMSimulator.Factory.Interface;
using ATMSimulator.Factory.Option;

namespace ATMSimulator.Factory;

class TransferFactory : OptionFactory
{
    public override IOption BuildOption()
    {
        return new Transfer();
    }
}