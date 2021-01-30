using System;

using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormRotation.Interface;
using ImageProcessing.App.UILayer.FormModel.Model.Rotate;
using ImageProcessing.App.UILayer.FormModel.Model.Rotate.DestinationContainer.Implementation;
using ImageProcessing.App.UILayer.FormModel.Model.Rotate.SourceContainer.Implementation;

namespace ImageProcessing.App.UILayer.FormModel.Factory.MainFormRotation.Implementation
{
    internal class MainFormRotationFactory : IMainFormRotationFactory
    {
        public RotateContainer Get(ImageContainer container)
             => container
        switch
         {
             ImageContainer.Source
                 => new RotateSourceContainer(),
             ImageContainer.Destination
                 => new RotateDestinationContainer(),

             _   => throw new NotSupportedException(nameof(container))
        };
    }
}
