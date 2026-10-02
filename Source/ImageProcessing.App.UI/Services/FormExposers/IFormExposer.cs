namespace ImageProcessing.App.UI.Services.FormExposers
{
    internal interface IFormExposer<in TExposer>
        where TExposer : class
    {
        void OnElementExpose(TExposer form);
    }
}
