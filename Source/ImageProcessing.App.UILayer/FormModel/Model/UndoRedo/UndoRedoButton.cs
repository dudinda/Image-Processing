using System;
using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.UILayer.FormModel.Model.UndoRedo
{
    internal abstract class UndoRedoButton : IFormExposer<IMainFormExposer, UndoRedoButton>
    {
        protected IMainFormExposer? _exposer;

        protected IMainFormExposer Exposer
        {
            get
            {
                if (_exposer is null)
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

        public abstract void Add(ImageContainer to, Bitmap bmp);
        public abstract (Bitmap Bmp, ImageContainer To) Pop();

        public UndoRedoButton OnElementExpose(IMainFormExposer form)
        {
            Exposer = form; return this;
        }
    }
}
