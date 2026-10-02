namespace ImageProcessing.App.UILayer.Services.FormExposers
{
    internal interface IFormExposer<in TExposer>
        where TExposer : class
    {
        void OnElementExpose(TExposer form);
    }
}
