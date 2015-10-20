// Created 15.10.2015
// Modified by Александр 20.10.2015 at 19:52

namespace Assets.Scripts.Engine.Presenter {
    internal interface IPresenter<in TView> {
        void Init(TView view);
        void DeInit();
    }
}