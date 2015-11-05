// Created 04.11.2015 
// Modified by Gorbach Alex 04.11.2015 at 8:41

namespace Assets.Scripts.ZenjectConfig.Global {
    #region References

    using SmartLocalization;
    using State.Levels.Loaders;
    using State.Levels.Storage;
    using State.Progress;
    using State.Progress.Storage;
    using State.ScenesInteraction.Loaders;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class GlobalInstaller : MonoInstaller {
        [SerializeField]
        private string _levelsPath;

        public override void InstallBindings() {
            //            Container.Bind<PresenterFactory>().ToSingle();
            Container.Bind<ILevelStorage>().ToSingle<LevelStorage>();
            Container.Bind<ILevelLoader>().ToTransient<ResourcesLevelLoader>();
            Container.Bind<string>().ToInstance(_levelsPath).WhenInjectedInto<ResourcesLevelLoader>();
            Container.Bind<IProgressStorage>().ToSingle<ProgressStorage>();
            Container.Bind<LevelProgress.Factory>().ToTransient();
            Container.Bind<ISceneLoader>().ToSingle<SceneLoader>();
            Container.Bind<LanguageManager>().ToSingleInstance(LanguageManager.Instance);
        }
    }
}