// Created 06.11.2015
// Modified by  25.11.2015 at 12:49

namespace Assets.Scripts.EndlessEngine {
    #region References

    using Engine;

    #endregion

    internal abstract class AbstractGenerator : MonoBehaviourBase {
        //private bool _isStopped;

        protected bool CanGenerate {
            get { return true; }
        }

        //public void Stop() {
        //    _isStopped = true;
        //}
    }
}