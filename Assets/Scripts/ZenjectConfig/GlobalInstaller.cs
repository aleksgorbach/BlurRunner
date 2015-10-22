// Created 22.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 15:12

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using State.Progress.Storage;
    using State.ScenesInteraction.Dependencies;
    using State.ScenesInteraction.Loaders;
    using State.Levels.Storage;
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