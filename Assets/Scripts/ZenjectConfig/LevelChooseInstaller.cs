// Created 15.10.2015
// Modified by Александр 15.10.2015 at 21:21

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using Engine.Presenter;
    using State.Levels.Storage;
    using UI.Menus.Levels;
    using UI.Menus.Levels.LevelItem;
    using UI.Menus.Levels.Presenter;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class LevelChooseInstaller : MonoInstaller {
        [SerializeField] private LevelItemUI _levelPrefab;

        public override void InstallBindings() {
            Container.BindGameObjectFactory<LevelItemUI>(_levelPrefab.gameObject);
            Container.Bind<IPresenter<ILevelChoosingMenuUI>>().ToTransient<LevelChoosingPresenter>();
            Container.Bind<ILevelStorage>().ToSingle<LevelStorage>();
        }
    }
}