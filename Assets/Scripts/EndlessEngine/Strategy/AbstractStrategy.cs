// Created 06.11.2015 
// Modified by Gorbach Alex 06.11.2015 at 14:31

namespace Assets.Scripts.EndlessEngine.Strategy {
    #region References

    using System;
    using Engine;

    #endregion

    internal abstract class AbstractStrategy : MonoBehaviourBase, IGeneratingStrategy {
        public event Action NeedGenerate;

        protected void OnNeedGenerate() {
            var handler = NeedGenerate;
            if (handler != null) {
                handler.Invoke();
            }
        }
    }
}