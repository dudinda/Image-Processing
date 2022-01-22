
using ImageProcessing.App.UILayer.UIModel.Models.MainMenuState.Interface;

namespace ImageProcessing.App.UILayer.UIModel.Models.MenuState.Implementation
{
    public class ImageEmptyMenuState : IMainMenuState
    {
        public bool ConvolutionMenuState => false;

        public bool RgbMenuState => false;

        public bool DistributionMenuState => false;

        public bool TransformationMenuState => false;

        public bool ScalingMenuState => false;

        public bool RotationMenuState => false;

        public bool SettingsMenuState => false;

        public bool SetSourceImageState => false;

        public bool MorphologyMenuState => false;

        public bool RotationTrackBarState => false;

        public bool ScalingTrackBarState => false;
    }
}
