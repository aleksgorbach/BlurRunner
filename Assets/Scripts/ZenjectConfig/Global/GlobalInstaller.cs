// Created 22.10.2015 
// Modified by Gorbach Alex 03.11.2015 at 15:00

namespace Assets.Scripts.ZenjectConfig.Global {
    #region References

    using Localization.Locales;
    using Localization.Localizators;
    using State.Levels.Loaders;
    using State.Levels.Storage;
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
            Container.Bind<ISceneLoader>().ToSingle<SceneLoader>();
            Container.Bind<ILocalizator>().ToSingle<DefaultLocalizator>();
            Container.Bind<Locale>(DefaultLocalizator.DEFAULT_LOCALE_KEY).ToSingle<RussianLocale>();
        }
    }
}