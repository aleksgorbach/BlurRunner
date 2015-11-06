// Created 23.10.2015 
// Modified by Gorbach Alex 06.11.2015 at 9:59

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using System;
    using System.Collections.Generic;
    using Assets.Scripts.Gameplay.GameState.StateChangedSources;
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
            Container.Bind<IPauseSource>().ToInstance(_guiController);
            Container.Bind<IRunSource>().ToInstance(_popupController);
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