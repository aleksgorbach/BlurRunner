// Created 22.10.2015
// Modified by Александр 26.10.2015 at 21:51

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using State.Levels.Loaders;
    using State.Levels.Storage;
    using State.Progress.Storage;
    using State.ScenesInteraction.Dependencies;
    using State.ScenesInteraction.Loaders;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class GlobalInstaller : MonoInstaller {
        [SerializeField]
        private TextAsset _levelData;

        public override void InstallBindings() {
            //            Container.Bind<PresenterFactory>().ToSingle();
            Container.Bind<ILevelStorage>().ToSingle<LevelStorage>();
            Container.Bind<ILevelLoader>().ToTransient<ResourcesLevelLoader>();
            Container.Bind<TextAsset>().ToInstance(_levelData).WhenInjectedInto<ResourcesLevelLoader>();
            Container.Bind<IProgressStorage>().ToSingle<ProgressStorage>();
            Container.Bind<ISceneLoader>().ToSingle<SceneLoader>();
            Container.Bind<ISceneOrder>().ToSingle<SceneOrder>();
        }
    }
}