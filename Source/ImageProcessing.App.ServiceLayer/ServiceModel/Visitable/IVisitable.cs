namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitable
{
    public interface IVisitable<out TVisitable, in TVisitor>
    {
        TVisitable Accept(TVisitor visitor);
    }
}
