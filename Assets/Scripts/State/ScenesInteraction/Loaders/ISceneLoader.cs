// Created 22.10.2015
// Modified by Александр 01.11.2015 at 17:31

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    internal enum Scene {
        Logo,
        LevelChoose,
        Game
    }

    internal interface ISceneLoader {
        /// <summary>
        /// Loads next scene
        /// </summary>
        void GoToScene(Scene scene);
    }
}