using System;
using System.Drawing;

using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormModel.Model.UndoRedo
{
    internal abstract class UndoRedoButton : IFormExposer<IMainFormExposer, UndoRedoButton>
    {
        protected IMainFormExposer? _exposer;

        protected IMainFormExposer Exposer
        {
            get => _exposer ?? throw new ArgumentNullException(nameof(Exposer));
            private set => _exposer = value;
        }

        public abstract void Add(ImageContainer to, Bitmap bmp);
        public abstract (Bitmap Bmp, ImageContainer To) Pop();

        public UndoRedoButton OnElementExpose(IMainFormExposer form)
        {
            Exposer = form; return this;
        }
    }
}
