using ImageProcessing.App.UI.Models.MenuState;

namespace ImageProcessing.App.UI.Models.MenuState.Implementation
{
    public sealed class ImageLoadedMenuState : IMainMenuState
    {
        public bool ConvolutionMenuState => true;

        public bool RgbMenuState => true;

        public bool DistributionMenuState => true;

        public bool TransformationMenuState => true;

        public bool ScalingMenuState => true;

        public bool RotationMenuState => true;

        public bool SettingsMenuState => true;

        public bool SetSourceImageState => true;

        public bool MorphologyMenuState => true;

        public bool RotationTrackBarState => true;

        public bool ScalingTrackBarState => true;
    }
}
