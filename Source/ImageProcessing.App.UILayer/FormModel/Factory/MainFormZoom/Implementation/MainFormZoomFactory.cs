using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormZoom.Interface;
using ImageProcessing.App.UILayer.FormModel.Model.Zoom;
using ImageProcessing.App.UILayer.FormModel.Model.Zoom.DestinationContainer.Implementation;
using ImageProcessing.App.UILayer.FormModel.Model.Zoom.SourceContainer.Implementation;

namespace ImageProcessing.App.UILayer.FormModel.Factory.MainFormZoom.Implementation
{
    internal class MainFormZoomFactory : IMainFormZoomFactory
    {
        public ZoomContainer Get(ImageContainer container)
             => container
        switch
         {
             ImageContainer.Source
                 => new ZoomSourceContainer(),
             ImageContainer.Destination
                 => new ZoomDestinationContainer(),

             _ => throw new NotSupportedException(nameof(container))
        };
    }
}
