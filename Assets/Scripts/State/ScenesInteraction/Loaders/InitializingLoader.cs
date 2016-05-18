// Created 28.12.2015
// Modified by  28.12.2015 at 10:44

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using Engine;

    #endregion

    internal abstract class InitializingLoader : MonoBehaviourBase {
        public abstract bool IsLoaded { get; }
    }
}