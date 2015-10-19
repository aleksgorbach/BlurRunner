// Created 15.10.2015
// Modified by Александр 18.10.2015 at 19:03

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
            Container.BindGameObjectFactory<LevelItemUI.Factory>(_levelPrefab.gameObject);
            Container.Bind<IPresenter<ILevelChoosingMenuUI>>().ToTransient<LevelChoosingPresenter>();
            Container.Bind<ILevelStorage>().ToSingle<LevelStorage>();
        }
    }
}