namespace ImageProcessing.PresentationLayer.Views.ViewComponent.BitmapInfo
{
    public interface IBitmapInfo
    {
        /// <summary>
        /// Parameters is used during the histogram
        /// transorfmation by a specified distribution.
        /// </summary>
        (string, string) Parameters { get; }

        /// <summary>
        /// Show the information about <see cref="RandomVariable"/>
        /// value of the specified <see cref="ImageContainer"/>.
        /// </summary>
        /// <param name="info"></param>
        void ShowInfo(string info);
    }
}
