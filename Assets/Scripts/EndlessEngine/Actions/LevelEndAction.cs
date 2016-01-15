// Created 15.01.2016
// Modified by  15.01.2016 at 8:41

namespace Assets.Scripts.EndlessEngine.Actions {
    #region References

    using System;
    using Engine.Extensions;
    using Gameplay.GameState.StateChangedSources;

    #endregion

    internal class LevelEndAction : MonoAction, IWinSource {
        public event EventHandler<WinSourceArgs> Win;

        private void OnReached() {
            Win.SafeInvoke(this, new WinSourceArgs());
        }

        public override Action Action {
            get { return OnReached; }
        }
    }
}