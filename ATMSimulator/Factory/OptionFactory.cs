using System;
using ATMSimulator.Factory.Interface;

namespace ATMSimulator.Factory;

abstract class OptionFactory
{
    protected OptionFactory()
    {
        UserInterface.InitView();
    }
    public abstract IOption BuildOption();

    public void Testing()
    {
        var option = BuildOption();
        option.DisplayOption();
    }
}