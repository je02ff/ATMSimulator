using System;
using ATMSimulator.Factory.Interface;

namespace ATMSimulator.Factory;

abstract class OptionFactory
{
    public abstract IOption BuildOption();

    public void LoadOption()
    {
        var option = BuildOption();
        option.DisplayOption();
    }
}