// Created 22.10.2015
// Modified by Александр 22.10.2015 at 20:21

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using State.Levels.Storage;
    using State.Progress.Storage;
    using State.ScenesInteraction.Dependencies;
    using State.ScenesInteraction.Loaders;
    using Zenject;

    #endregion

    internal class GlobalInstaller : MonoInstaller {
        public override void InstallBindings() {
            //            Container.Bind<PresenterFactory>().ToSingle();
            Container.Bind<ILevelStorage>().ToSingle<LevelStorage>();
            Container.Bind<IProgressStorage>().ToSingle<ProgressStorage>();
            Container.Bind<ISceneLoader>().ToSingle<SceneLoader>();
            Container.Bind<ISceneOrder>().ToSingle<SceneOrder>();
        }
    }
}