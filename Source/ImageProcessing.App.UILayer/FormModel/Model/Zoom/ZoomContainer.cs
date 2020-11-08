using System;
using System.Drawing;

using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormModel.Model.Zoom
{
    internal abstract class ZoomContainer : IFormExposer<IMainFormExposer, ZoomContainer>
    {
        private IMainFormExposer? _exposer;

        protected IMainFormExposer Exposer
        {
            get
            {
                if(_exposer is null)
                {
                    throw new ArgumentNullException(nameof(_exposer));
                }

                return _exposer;
            }

            private set
            {
                _exposer = value;
            }
        }

        public abstract void SetZoomImage(Image image);
        public abstract void ResetTrackBarValue(int value = 0);

        public ZoomContainer OnElementExpose(IMainFormExposer form)
        {
            _exposer = form; return this;
        }
    }
}
