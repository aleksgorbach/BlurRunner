// Created 03.11.2015
// Modified by Александр 03.11.2015 at 19:58

namespace Assets.Scripts.ZenjectConfig.Global {
    #region References

    using Localization.Keys;
    using Purchases;
    using Purchases.Handlers;
    using Purchases.Storage;
    using Zenject;

    #endregion

    internal class InAppInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container.Bind<IInAppStorage>().ToSingle<InAppStorage>();
            Container.Bind<IInAppHandler>().ToSingle<EditorInAppHandler>();
            Container.Bind<IInAppItem>()
                .ToInstance(new InAppItem(InAppKeys.VITAMINE_NAME, InAppKeys.VITAMINE_DESCRIPTION,
                    InAppKeys.VITAMINE_EFFECT));
            Container.Bind<IInAppItem>()
                .ToInstance(new InAppItem(InAppKeys.BOOK_NAME, InAppKeys.BOOK_DESCRIPTION,
                    InAppKeys.BOOK_EFFECT));
        }
    }
}