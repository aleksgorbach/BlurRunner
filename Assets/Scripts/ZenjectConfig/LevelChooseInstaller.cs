// Created 15.10.2015
// Modified by Александр 20.10.2015 at 20:30

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using Engine.Presenter;
    using UI.Menus.Levels.LevelItem;
    using UI.Menus.Levels.Presenter;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class LevelChooseInstaller : MonoInstaller {
        [SerializeField]
        private LevelItem _levelPrefab;

        public override void InstallBindings() {
            Container.Bind<PresenterFactory>().ToSingle();
            Container.BindGameObjectFactory<LevelItem.Factory>(_levelPrefab.gameObject);
            Container.Bind<LevelChoosingPresenter>().ToTransient();
            
        }
    }
}