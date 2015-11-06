// Created 06.11.2015 
// Modified by Gorbach Alex 06.11.2015 at 14:03

namespace Assets.Scripts.EndlessEngine {
    #region References

    using Engine;

    #endregion

    internal abstract class AbstractGenerator : MonoBehaviourBase {
        private bool _isStopped;

        protected bool CanGenerate {
            get {
                return !_isStopped;
            }
        }

        public void Stop() {
            _isStopped = true;
        }
    }
}