namespace ImageProcessing.App.ServiceLayer.CompoundModels.Visitable
{
    internal interface IVisitable<out TVisitable, in TVisitor>
    {
        TVisitable Accept(TVisitor visitor);
    }
}
