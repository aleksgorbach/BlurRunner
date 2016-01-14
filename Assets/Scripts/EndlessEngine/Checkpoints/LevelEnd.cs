// Created 22.12.2015
// Modified by  14.01.2016 at 9:04

namespace Assets.Scripts.EndlessEngine.Checkpoints {
    #region References

    using System;
    using Engine.Extensions;
    using Gameplay.GameState.StateChangedSources;

    #endregion

    internal class LevelEnd : Checkpoint, IWinSource {
        public event EventHandler<WinSourceArgs> Win;

        protected override void OnReached() {
            Win.SafeInvoke(this, new WinSourceArgs());
        }
    }
}