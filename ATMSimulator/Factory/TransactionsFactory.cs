using ATMSimulator.Factory.Interface;
using ATMSimulator.Factory.Option;

namespace ATMSimulator.Factory;

class TransactionsFactory : OptionFactory
{
    public override IOption BuildOption()
    {
        return new Transactions();
    }
}