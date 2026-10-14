namespace ImageProcessing.App.UI.Models.MenuState
{
    public interface IMainMenuState
    {
        /// <summary>
        /// State of the convolution menu button.
        /// </summary>
        bool ConvolutionMenuState { get; }

        /// <summary>
        /// State of the convolution menu button.
        /// </summary>
        bool RgbMenuState { get; }

        /// <summary>
        /// State of the convolution menu button.
        /// </summary>
        bool DistributionMenuState { get; }

        /// <summary>
        /// State of the convolution menu button.
        /// </summary>
        bool TransformationMenuState { get; }

        /// <summary>
        /// State of the convolution menu button.
        /// </summary>
        bool ScalingMenuState { get; }

        /// <summary>
        /// State of the convolution menu button.
        /// </summary>
        bool RotationMenuState { get; }

        /// <summary>
        /// State of the convolution menu button.
        /// </summary>
        bool SettingsMenuState { get; }

        /// <summary>
        /// State of the convolution menu button.
        /// </summary>
        bool MorphologyMenuState { get; }

        /// <summary>
        /// State of the convolution menu button.
        /// </summary>
        bool RotationTrackBarState { get; }

        /// <summary>
        /// State of the convolution menu button.
        /// </summary>
        bool ScalingTrackBarState { get; }

        /// <summary>
        /// State of the select area toobar button.
        /// </summary>
        public bool SelectAreaState { get; }

        /// <summary>
        /// State of the restore source image toolbar button.
        /// </summary>
        bool SetSourceImageState { get; }
    }
}
