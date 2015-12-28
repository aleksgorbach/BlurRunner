// Created 04.11.2015
// Modified by  28.12.2015 at 9:03

namespace Assets.Scripts.ZenjectConfig.Global {
    #region References

    using SmartLocalization;
    using State.Levels.Loaders;
    using State.Levels.Storage;
    using State.PlayerPrefs;
    using State.ScenesInteraction.Loaders;
    using UnityEngine;
    using Zenject;
    using PlayerPrefs = State.PlayerPrefs.PlayerPrefs;

    #endregion

    internal class GlobalInstaller : MonoInstaller {
        [SerializeField]
        private string _levelsPath;

        [SerializeField]
        private SceneLoader _sceneLoader;

        public override void InstallBindings() {
            Container.Bind<ILevelStorage>().ToSingle<LevelStorage>();
            Container.Bind<ILevelLoader>().ToTransient<ResourcesLevelLoader>();
            Container.Bind<string>().ToInstance(_levelsPath).WhenInjectedInto<ResourcesLevelLoader>();


            Container.Bind<LanguageManager>().ToSingleInstance(LanguageManager.Instance);
            Container.Bind<ISceneLoader>().ToSinglePrefab<SceneLoader>(_sceneLoader.gameObject);
            Container.Bind<IPlayerPrefs>().ToTransient<PlayerPrefs>();
        }
    }
}