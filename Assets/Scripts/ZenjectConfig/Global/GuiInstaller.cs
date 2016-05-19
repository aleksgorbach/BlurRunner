// Created 23.10.2015
// Modified by  20.01.2016 at 14:22

namespace Assets.Scripts.ZenjectConfig.Global {
    #region References

    using UI.Popups;
    using UI.Popups.Controller;
    using UI.Popups.Factory;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class GuiInstaller : MonoInstaller {
        [SerializeField]
        private PopupController _popupControllerPrefab;

        [SerializeField]
        private Popup[] _popups;

        public override void InstallBindings() {
            Container.Bind<Popup[]>().ToInstance(_popups);
            Container.Bind<PopupFactory>().ToTransient();
            Container.Bind<PopupStrategy>().ToTransient();
            Container.Bind<IPopupController>().ToSinglePrefab<PopupController>(_popupControllerPrefab.gameObject);
        }
    }
}