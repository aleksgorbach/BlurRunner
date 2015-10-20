// Created 20.10.2015
// Modified by Александр 20.10.2015 at 20:58

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using State.Levels.Storage;
    using Zenject;

    #endregion

    internal class GlobalInstaller : MonoInstaller {
        public override void InstallBindings() {
            //            Container.Bind<PresenterFactory>().ToSingle();
            Container.Bind<ILevelStorage>().ToSingle<LevelStorage>();
        }
    }
}