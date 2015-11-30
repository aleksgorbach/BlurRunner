// Created 23.10.2015
// Modified by  30.11.2015 at 11:38

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using UI.Popups;
    using UI.Popups.Controller;
    using UI.Popups.Factory;
    using UI.Visualizers.Bonuses;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class GuiInstaller : MonoInstaller {
        [SerializeField]
        private BonusVisualizer _bonusVisualizer;

        [SerializeField]
        private PopupController _popupController;

        [SerializeField]
        private Popup[] _popups;

        public override void InstallBindings() {
            Container.Bind<IPopupController>().ToSingleInstance(_popupController);
            Container.Bind<IBonusVisualizer>().ToInstance(_bonusVisualizer);
            Container.Bind<Popup[]>().ToInstance(_popups);
            Container.Bind<PopupFactory>().ToTransient();
            Container.Bind<PopupStrategy>().ToTransient();
        }
    }
}