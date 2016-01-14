// Created 14.01.2016
// Modified by  14.01.2016 at 9:01

namespace Assets.Scripts.EndlessEngine.Checkpoints {
    #region References

    using Engine;
    using UnityEngine;

    #endregion

    internal abstract class Checkpoint : MonoBehaviourBase {
        private void OnTriggerExit2D(Collider2D collision) {
            OnReached();
        }

        protected abstract void OnReached();
    }
}