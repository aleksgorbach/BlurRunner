// Created 15.10.2015
// Modified by Александр 15.10.2015 at 21:20

namespace Assets.Scripts.Engine.Presenter {
    #region References

    

    #endregion

    internal abstract class Presenter<TView> : IPresenter<TView> {
        protected TView View { get; private set; }

        public virtual void Init(TView view) {
            View = view;
        }
    }
}