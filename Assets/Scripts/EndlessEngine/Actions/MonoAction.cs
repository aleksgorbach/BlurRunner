// Created 15.01.2016
// Modified by  15.01.2016 at 8:37

namespace Assets.Scripts.EndlessEngine.Actions {
    #region References

    using System;
    using Engine;

    #endregion

    internal abstract class MonoAction : MonoBehaviourBase {
        public abstract Action Action { get; }
    }
}