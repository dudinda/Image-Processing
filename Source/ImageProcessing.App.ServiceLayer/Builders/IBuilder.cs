namespace ImageProcessing.App.ServiceLayer.Builders.Base
{
    /// <summary>
    /// Provides a base interface for builders.
    /// </summary
    public interface IBuilder<out TModel>
    {
        /// <summary>
        /// Built the specified <typeparamref name="TModel"/>
        /// </summary>
        TModel Build();
    }
}
