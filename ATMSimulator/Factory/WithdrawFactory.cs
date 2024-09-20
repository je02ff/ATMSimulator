using ATMSimulator.Factory.Interface;
using ATMSimulator.Factory.Option;

namespace ATMSimulator.Factory;

class WithdrawFactory : OptionFactory
{
    public override IOption BuildOption()
    {
        return new Withdraw();
    }
}