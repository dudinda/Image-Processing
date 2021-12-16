using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Scaling.Interface;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.App.UILayer.Forms.Scaling;

using MetroFramework.Controls;

namespace ImageProcessing.App.Integration.Monolith.UILayer.Forms
{
    internal class ScalingFormWrapper : IScalingView, IScalingFormExposer
    {
        private readonly ScalingForm _form;

        public ScalingFormWrapper(
            IMainView main,
            IScalingFormEventBinderWrapper binder)
        {
            _form = new ScalingForm(main, binder);
        }

        public (string, string) Parameters => throw new NotImplementedException();

        public ScalingMethod Dropdown => throw new NotImplementedException();

        public MetroButton ScaleButton => throw new NotImplementedException();

        public event FormClosedEventHandler FormClosed;

        public void Close()
        {
            throw new NotImplementedException();
        }

        public bool Focus()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Tooltip(string message)
        {
            throw new NotImplementedException();
        }
    }
}
