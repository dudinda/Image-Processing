﻿using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.View;

namespace ImageProcessing.Core.Presenter.Abstract
{
    public abstract class BasePresenter<TView> : IPresenter
        where TView : IView
    {
        protected TView View { get; private set; }
        protected IAppController Controller { get; private set; }

        protected BasePresenter(IAppController controller, TView view)
        {
            Controller = controller;
            View       = view;
        }

        public void Run() => View.Show();
    }

    public abstract class BasePresenter<TView, TViewModel> : IPresenter<TViewModel>
        where TView : IView
    {
        protected TView View { get; private set; }
        protected IAppController Controller { get; private set; }

        protected BasePresenter(IAppController controller, TView view)
        {
            Controller = controller;
            View       = view;
        }

        public abstract void Run(TViewModel argument);
    }
}