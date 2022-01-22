namespace ImageProcessing.App.UILayer.FormExposers
{
    internal interface IFormExposer<in TExposer>
        where TExposer : class
    {
        void OnElementExpose(TExposer form);
    }
}
