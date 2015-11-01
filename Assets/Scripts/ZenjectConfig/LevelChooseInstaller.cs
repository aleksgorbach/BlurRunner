// Created 22.10.2015
// Modified by Александр 01.11.2015 at 17:55

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using Engine.Presenter;
    using UI.Menus.Levels.LevelItem;
    using UI.Menus.Levels.Presenter;
    using UI.Visualizers.Stars;
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
        }
    }
}