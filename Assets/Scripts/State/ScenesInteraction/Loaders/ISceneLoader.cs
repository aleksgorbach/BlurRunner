// Created 22.10.2015 
// Modified by Gorbach Alex 05.11.2015 at 9:55

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    internal enum Scene {
        Logo,
        LevelChoose,
        Shop,
        Game
    }

    internal interface ISceneLoader {
        /// <summary>
        /// Loads next scene
        /// </summary>
        void GoToScene(Scene scene);
    }
}