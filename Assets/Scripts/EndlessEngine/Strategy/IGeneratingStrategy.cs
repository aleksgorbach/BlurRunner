// Created 06.11.2015 
// Modified by Gorbach Alex 06.11.2015 at 14:30

namespace Assets.Scripts.EndlessEngine.Strategy {
    #region References

    using System;

    #endregion

    internal interface IGeneratingStrategy {
        event Action NeedGenerate;
    }
}