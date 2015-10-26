﻿// Created 26.10.2015 
// Modified by Gorbach Alex 26.10.2015 at 11:13

namespace Assets.Scripts.EndlessEngine.Ground.Decorations.Strategy {
    #region References

    using Assets.Scripts.Engine;

    #endregion

    internal abstract class AbstractStrategy : MonoBehaviourBase, IGeneratingStrategy {
        public abstract bool IsGeneratingNeeded { get; }
    }
}