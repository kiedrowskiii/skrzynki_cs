public abstract class CaseDecorator : ICase
{
    protected ICase wrappedCase;

    public CaseDecorator(ICase wrappedCase)
    {
        this.wrappedCase = wrappedCase;
    }

    public virtual string Open()
    {
        return wrappedCase.Open();
    }
}
