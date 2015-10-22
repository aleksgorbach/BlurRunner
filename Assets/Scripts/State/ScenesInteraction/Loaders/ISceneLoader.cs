// Created 22.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 14:52

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    internal interface ISceneLoader {
        /// <summary>
        /// Loads next scene
        /// </summary>
        /// <returns>True, if next scene exists, otherwise false</returns>
        bool GoToNextScene();

        /// <summary>
        /// Loads previous scene
        /// </summary>
        /// <returns>True, if previous scene exists, otherwise false</returns>
        bool GoToPreviousScene();
    }
}