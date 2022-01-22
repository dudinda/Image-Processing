namespace ImageProcessing.App.UILayer.UIModel.Models.MainMenuState.Interface
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
        bool SetSourceImageState { get; }

        /// <summary>
        /// State of the convolution menu button.
        /// </summary>
        bool RotationTrackBarState { get; }

        /// <summary>
        /// State of the convolution menu button.
        /// </summary>
        bool ScalingTrackBarState { get; }
    }
}
