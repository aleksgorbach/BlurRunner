namespace Assets.Scripts.Engine.Presenter {
    interface IPresenter<TView> {
        void Init(TView view);
    }
}
