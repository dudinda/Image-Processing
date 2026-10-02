namespace ImageProcessing.App.Domain.Providers.Visitable
{
    public interface IVisitable<out TVisitable, in TVisitor>
    {
        TVisitable Accept(TVisitor visitor);
    }
}
