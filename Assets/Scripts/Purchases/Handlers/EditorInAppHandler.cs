// Created 03.11.2015 
// Modified by Gorbach Alex 03.11.2015 at 14:10

namespace Assets.Scripts.Purchases.Handlers {
    #region References

    using UnityEngine;

    #endregion

    internal class EditorInAppHandler : IInAppHandler {
        public void Purchase(IInAppItem item) {
            Debug.Log("purchased: " + item);
        }
    }
}