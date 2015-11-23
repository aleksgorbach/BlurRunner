// Created 10.11.2015
// Modified by  23.11.2015 at 14:55

namespace Assets.Scripts.EndlessEngine {
    #region References

    using Engine;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof (Collider2D))]
    internal class ObjectRemoveTrigger : MonoBehaviourBase {
        private void OnTriggerExit2D(Collider2D collision) {
            // todo не искать компонент, особенно в родителях
            var removable = collision.gameObject.GetComponentInParent(typeof (IRemovable));
            if (removable != null) {
                (removable as IRemovable).Remove();
            }
        }
    }
}