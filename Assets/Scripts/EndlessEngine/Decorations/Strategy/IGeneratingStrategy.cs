// Created 26.10.2015 
// Modified by Gorbach Alex 26.10.2015 at 10:29

namespace Assets.Scripts.EndlessEngine.Decorations.Strategy {
    internal interface IGeneratingStrategy {
        bool IsGeneratingNeeded { get; }
    }
}