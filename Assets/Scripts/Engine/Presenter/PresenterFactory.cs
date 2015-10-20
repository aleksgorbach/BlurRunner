// Created 20.10.2015
// Modified by Александр 20.10.2015 at 20:26

namespace Assets.Scripts.Engine.Presenter {
    #region References

    using Zenject;

    #endregion

    internal class PresenterFactory {
        private readonly DiContainer _container;

        protected PresenterFactory(DiContainer container) {
            _container = container;
        }

        public TPresenter Create<TPresenter, TView>(TView view) where TPresenter : IPresenter<TView> {
            var presenter = _container.Resolve<TPresenter>();
            presenter.Init(view);
            return presenter;
        }
    }
}