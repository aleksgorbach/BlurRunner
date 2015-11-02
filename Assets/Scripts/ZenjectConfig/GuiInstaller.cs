﻿// Created 22.10.2015
// Modified by Александр 02.11.2015 at 20:06

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using System;
    using System.Collections.Generic;
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
                get { return _popupsPrefabs; }
            }
        }
    }
}