// Created 15.10.2015
// Modified by Александр 21.10.2015 at 20:10

namespace Assets.Scripts.Engine.Presenter {
    internal abstract class Presenter<TView> : IPresenter<TView> where TView : class {
        protected TView View;

        public virtual void Init(TView view) {
            View = view;
        }

        public virtual void DeInit() {
        }
    }
}