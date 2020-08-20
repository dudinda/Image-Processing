namespace ImageProcessing.App.ServiceLayer.ServiceModel.Visitable
{
    internal interface IVisitable<out TVisitable, in TVisitor>
    {
        TVisitable Accept(TVisitor visitor);
    }
}
