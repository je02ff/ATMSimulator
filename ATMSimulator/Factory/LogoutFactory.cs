using ATMSimulator.Factory.Interface;
using ATMSimulator.Factory.Option;

namespace ATMSimulator.Factory;

class LogoutFactory : OptionFactory
{
    public override IOption BuildOption()
    {
        return new Logout();
    }
}