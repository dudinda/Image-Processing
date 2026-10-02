namespace ImageProcessing.App.ServiceLayer.Providers.Visitable
{
    public interface IVisitable<out TVisitable, in TVisitor>
    {
        TVisitable Accept(TVisitor visitor);
    }
}
