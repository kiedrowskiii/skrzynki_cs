using System;

public class StatTrakDecorator : CaseDecorator
{
    public StatTrakDecorator(ICase wrappedCase) : base(wrappedCase) {}

    public override string Open()
    {
        string item = base.Open();

        Random rng = new Random();
        bool isStatTrak = rng.Next(100) < 20;

        if (isStatTrak)
            return "StatTrak™ " + item;

        return item;
    }
}
