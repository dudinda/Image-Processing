using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Rotation.Interface;
using ImageProcessing.App.UILayer.FormExposers;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Rotation.Implementation
{
    internal class RotationFormEventBinderWrapper : IRotationFormEventBinderWrapper
    {
        public void OnElementExpose(IRotationFormExposer form)
        {
            throw new NotImplementedException();
        }

        public bool ProcessCmdKey(IRotationFormExposer view, Keys keyData)
        {
            throw new NotImplementedException();
        }
    }
}
