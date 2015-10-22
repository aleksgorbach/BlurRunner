// Created 20.10.2015
// Modified by Александр 20.10.2015 at 20:56

namespace Assets.Scripts.State.ScenesInteraction.Dependencies {
    internal interface ISceneOrder {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Next scene name if exists, otherwise null</returns>
        string GetNextScene();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Previous scene name if exists, otherwise null</returns>
        string GetPreviousScene();
    }
}