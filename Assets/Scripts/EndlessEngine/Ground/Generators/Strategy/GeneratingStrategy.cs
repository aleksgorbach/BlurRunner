// Created 20.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 15:27

namespace Assets.Scripts.EndlessEngine.Ground.Generators.Strategy {
    #region References

    using Engine;

    #endregion

    public delegate void GeneratingDelegate();

    internal abstract class GeneratingStrategy : MonoBehaviourBase {
        public abstract void Init(GeneratingDelegate generatingMethod);
    }
}