// Created 26.10.2015 
// Modified by Gorbach Alex 26.10.2015 at 14:17

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using Debug;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class DebugInstaller : MonoInstaller {
        [SerializeField]
        private bool _isDebug;

        public override void InstallBindings() {
            if (!_isDebug) {
                return;
            }
            Container.InstantiateComponentOnNewGameObject<TimeStop>("TimeStopper");
        }
    }
}