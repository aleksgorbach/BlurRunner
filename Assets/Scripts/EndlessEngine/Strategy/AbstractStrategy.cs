// Created 06.11.2015
// Modified by  27.11.2015 at 9:26

namespace Assets.Scripts.EndlessEngine.Strategy {
    #region References

    using Engine;

    #endregion

    internal abstract class AbstractStrategy : MonoBehaviourBase, IGeneratingStrategy {
        public abstract float DistanceToGenerate { get; }
    }
}