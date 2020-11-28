using System;

using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormModel.Model.Rotate
{
    internal abstract class RotateContainer : IFormExposer<IMainFormExposer, RotateContainer>
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

        public abstract void ResetTrackBarValue(int value = 0);
        public abstract double GetFactor();

        public RotateContainer OnElementExpose(IMainFormExposer form)
        {
            _exposer = form; return this;
        }
    }
}
