// Created 23.10.2015 
// Modified by Gorbach Alex 12.11.2015 at 10:20

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using UI.Popups.Controller;
    using UI.Visualizers.Bonuses;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class GuiInstaller : MonoInstaller {
        [SerializeField]
        private BonusVisualizer _bonusVisualizer;

        [SerializeField]
        private PopupController _popupController;

        public override void InstallBindings() {
            Container.Bind<IPopupController>().ToSingleInstance(_popupController);
            Container.Bind<IBonusVisualizer>().ToInstance(_bonusVisualizer);
        }
    }
}