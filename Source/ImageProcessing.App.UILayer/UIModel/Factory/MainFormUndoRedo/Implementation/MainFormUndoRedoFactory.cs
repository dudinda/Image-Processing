using System;

using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.UILayer.FormModel.MainFormUndoRedo.Interface;
using ImageProcessing.App.UILayer.FormModel.Model.RedoButton.Implementation;
using ImageProcessing.App.UILayer.FormModel.Model.UndoButton.Implementation;
using ImageProcessing.App.UILayer.FormModel.Model.UndoRedo;

namespace ImageProcessing.App.UILayer.FormModel.Factory.MainFormUndoRedo.Implementation
{
    internal class MainFormUndoRedoFactory : IMainFormUndoRedoFactory
    {
        public UndoRedoButton Get(UndoRedoAction action)
            => action
        switch
        {
            UndoRedoAction.Undo
                => new MainFormUndoButton(),
            UndoRedoAction.Redo
                => new MainFormRedoButton(),

            _   => throw new NotSupportedException(nameof(action))
        }; 
        
    }
}
