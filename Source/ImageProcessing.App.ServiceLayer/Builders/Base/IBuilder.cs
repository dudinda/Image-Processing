namespace ImageProcessing.App.ServiceLayer.Builders.Base
{
    public interface IBuilder<out TBuilder>
    {
        TBuilder Build();
    }
}
