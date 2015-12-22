// Created 22.12.2015
// Modified by  22.12.2015 at 10:12

namespace Assets.Scripts.EndlessEngine.Endpoints {
    #region References

    using System;
    using Engine;
    using Gameplay.GameState.StateChangedSources;
    using UnityEngine;

    #endregion

    internal class LevelEnd : MonoBehaviourBase, IWinSource {
        public event Action<IWinSource> Win;

        private void OnTriggerEnter2D(Collider2D collision) {
            OnWin();
        }

        private void OnWin() {
            var handler = Win;
            if (handler != null) {
                handler.Invoke(this);
            }
        }
    }
}