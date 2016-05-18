// Created 14.01.2016
// Modified by  15.01.2016 at 8:43

namespace Assets.Scripts.EndlessEngine.Checkpoints {
    #region References

    using Actions;
    using Engine;
    using UnityEngine;

    #endregion

    internal class Checkpoint : MonoBehaviourBase {
        [SerializeField]
        private MonoAction _action;

        private void OnTriggerExit2D(Collider2D collision) {
            OnReached();
        }

        private void OnReached() {
            _action.Action.Invoke();
        }
    }
}