// Created 04.11.2015
// Modified by  20.01.2016 at 12:37

namespace Assets.Scripts.ZenjectConfig.Global {
    #region References

    using Ads;
    using Services;
    using SmartLocalization;
    using State.Levels.Loaders;
    using State.Levels.Storage;
    using State.PlayerPrefs;
    using State.Progress.Storage;
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
            Container.BindAllInterfacesToSingle<ProgressStorage>();

            Container.Bind<LanguageManager>().ToSingleInstance(LanguageManager.Instance);
            Container.Bind<ISceneLoader>().ToSinglePrefab<SceneLoader>(_sceneLoader.gameObject);
            Container.Bind<IPlayerPrefs>().ToTransient<PlayerPrefs>();
            Container.Bind<IAdManager>().ToSingle<AdManager>();
            Container.Bind<IServicesConfig>().ToTransient<AndroidServicesConfig>();
        }
    }
}