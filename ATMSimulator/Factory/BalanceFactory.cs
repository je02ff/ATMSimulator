using ATMSimulator.Factory.Interface;

namespace ATMSimulator.Factory;

class BalanceFactory : OptionFactory
{
    // Note that the signature of the method still uses the abstract product
    // type, even though the concrete product is actually returned from the
    // method. This way the Creator can stay independent of concrete product
    // classes.
    public override IOption BuildOption()
    {
        return new Balance();
    }
}