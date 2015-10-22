// Created 20.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 15:12

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using UI.Visualizers.Stars;
    using UI.Visualizers.Stars.Presenter;
    using Engine.Presenter;
    using UI.Menus.Levels.LevelItem;
    using UI.Menus.Levels.Presenter;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class LevelChooseInstaller : MonoInstaller {
        [SerializeField]
        private LevelItem _levelPrefab;

        [SerializeField]
        private StatedStar _starPrefab;

        public override void InstallBindings() {
            //todo перенести эту фабрику в глобальный инсталлер
            Container.Bind<PresenterFactory>().ToSingle();
            Container.BindGameObjectFactory<LevelItem.Factory>(_levelPrefab.gameObject);
            Container.Bind<LevelChoosingPresenter>().ToTransient();
            Container.Bind<StarsVisualizerPresenter>().ToTransient();
            Container.BindGameObjectFactory<StarFactory>(_starPrefab.gameObject);
        }
    }
}