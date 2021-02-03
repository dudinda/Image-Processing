using System;
using System.Drawing;

using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormModel.Model.Container
{
    internal abstract class MainFormContainer : IFormExposer<IMainFormExposer, MainFormContainer>
    {
        private IMainFormExposer? _exposer;

        protected IMainFormExposer Exposer
        {
            get => _exposer ?? throw new ArgumentNullException(nameof(_exposer));
            private set => _exposer = value;
        }

        public abstract Image? GetCopy();
        public abstract bool ImageIsDefault();
        public abstract void Refresh();
        public abstract void SetCopy(Image image);
        public abstract  void SetImage(Image image);
        public abstract void SetImageCenter(Size size);

        public MainFormContainer OnElementExpose(IMainFormExposer form)
        {
            Exposer = form; return this;
        }
    }
}
