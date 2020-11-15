using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Extensions.EnumExt;
using ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Implementation;
using ImageProcessing.App.PresentationLayer.Presenters.ColorMatrix;
using ImageProcessing.App.PresentationLayer.Views.ColorMatrix;
using ImageProcessing.App.UILayer.FormEventBinder.ColorMatrix.Interface;
using ImageProcessing.App.UILayer.FormExposer.ColorMatrix;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Form.ColorMatrix
{
    internal sealed partial class ColorMatrixForm : BaseForm,
        IColorMatrixView, IColorMatrixFormExposer
    {
        private readonly IColorMatrixEventBinder _binder;

        public ColorMatrixForm(
            IAppController controller,
            IColorMatrixEventBinder binder) : base(controller)
        {
            InitializeComponent();  
            PopulateComboBox<ClrMatrix>(ColorMatrixComboBox);

            _binder = binder;
            _binder.OnElementExpose(this);
        }
          
        public ClrMatrix Dropdown
        {
            get => ColorMatrixComboBox
                .SelectedItem.ToString()
                .GetValueFromDescription<ClrMatrix>();
        }

        public MetroButton ApplyButton
            => ApplyColorMatrixButton;

        public ReadOnly2DArray<double> GetGrid()
        {
            var rows = ColorMatrixGrid.Rows.Count;
            var cols = ColorMatrixGrid.Columns.Count;

            var array = new double[rows, cols];

            for(var i = 0; i < ColorMatrixGrid.Rows.Count; ++i)
            {
                for(var j = 0; j < ColorMatrixGrid.Columns.Count; ++j)
                {
                    array[i, j] = (double)ColorMatrixGrid[j, i].Value;
                }
            }

            return new ReadOnly2DArray<double>(array);
        }
      
        public new void Show()
        {
            Focus();
            base.Show();
        }

        /// <summary>
        /// Used by a DI container to dispose the singleton form
        /// on Release().
        public new void Dispose()
        {
            if (components != null)
            {
                components.Dispose();
            }

            Controller
               .Aggregator
               .Unsubscribe(typeof(ColorMatrixPresenter), this);

            base.Dispose(true);
        }
    }
}

