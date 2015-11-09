// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 9:35

namespace Assets.Scripts.EndlessEngine {
    #region References

    using Engine;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof(Collider2D))]
    internal class ObjectRemoveTrigger : MonoBehaviourBase {
        private void OnTriggerExit2D(Collider2D collision) {
            var removable = collision.gameObject.GetComponent(typeof(IRemovable));
            if (removable != null) {
                (removable as IRemovable).Remove();
            }
        }
    }
}