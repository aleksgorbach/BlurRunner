// Created 23.10.2015
// Modified by  24.12.2015 at 10:18

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using UI.Popups;
    using UI.Popups.Controller;
    using UI.Popups.Factory;
    using UI.Visualizers.Bonuses;
    using UI.Visualizers.Health;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class GuiInstaller : MonoInstaller {
        [SerializeField]
        private HealthVisualizer _bonusVisualizer;

        [SerializeField]
        private PopupController _popupController;

        [SerializeField]
        private Popup[] _popups;

        public override void InstallBindings() {
            Container.Bind<IPopupController>().ToSingleInstance(_popupController);
            Container.Bind<IHealthVisualizer>().ToInstance(_bonusVisualizer);
            Container.Bind<Popup[]>().ToInstance(_popups);
            Container.Bind<PopupFactory>().ToTransient();
            Container.Bind<PopupStrategy>().ToTransient();
        }
    }
}