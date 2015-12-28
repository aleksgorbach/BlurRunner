// Created 04.11.2015 
// Modified by Gorbach Alex 04.11.2015 at 9:15

namespace Assets.Scripts.ZenjectConfig.Global {
    #region References

    using Purchases;
    using Purchases.Handlers;
    using Purchases.Storage;
    using Zenject;

    #endregion

    internal class InAppInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<IInAppStorage>().ToSingle<InAppStorage>();
            Container.Bind<IInAppHandler>().ToSingle<UnityIAPHandler>();
            Container.Bind<IInitializable>().ToSingle<UnityIAPHandler>();
            Container.Bind<IInAppItem>().ToInstance(new InAppItem("vitamine"));
            Container.Bind<IInAppItem>().ToInstance(new InAppItem("book"));
            Container.Bind<IInAppItem>().ToInstance(new InAppItem("health"));
            Container.Bind<IInAppItem>().ToInstance(new InAppItem("strength"));
            Container.Bind<IInAppItem>().ToInstance(new InAppItem("power"));
        }
    }
}