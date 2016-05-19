namespace Assets.Scripts.ZenjectConfig.Global {
    using System.Collections.Generic;
    using Effects.Vibro;
    using Settings;
    using Settings.Impl;
    using Zenject;

    internal class SettingsInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<ISettingsManager>().ToSingle<SettingsManager>();
            var vibroSetting = new VibroSetting();
            var soundSetting = new VibroSetting();
            Container.Bind<IDictionary<Setting, ISetting>>().ToInstance(new Dictionary<Setting, ISetting> {
                {Setting.Vibro, vibroSetting},
                {Setting.Sound, soundSetting}
            });
            Container.Bind<ISetting>().ToInstance(vibroSetting).WhenInjectedInto<VibroManager>();
            Container.Bind<VibroManager>().ToSingle();
        }
    }
}