// Created 23.10.2015 
// Modified by Gorbach Alex 11.11.2015 at 13:09

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using System;
    using System.Collections.Generic;
    using UI.Menus.Game;
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
        private PopupSettings _settings;

        [SerializeField]
        private GuiController _guiController;

        public override void InstallBindings() {
            Container.Bind<IPopupController>().ToSingleInstance(_popupController);
            Container.Bind<PopupPool.ISettings>().ToSingleInstance(_settings);
            Container.Bind<PopupPool>().ToSingle();
            Container.Bind<IBonusVisualizer>().ToInstance(_bonusVisualizer);
        }

        [Serializable]
        public class PopupSettings : PopupPool.ISettings {
            [SerializeField]
            private Popup[] _popupsPrefabs;

            public IEnumerable<Popup> Prefabs {
                get {
                    return _popupsPrefabs;
                }
            }
        }
    }
}