// Created 22.10.2015
// Modified by  07.12.2015 at 11:04

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    using System.Collections;

    internal enum Scene {
        Logo,
        LevelChoose,
        Shop,
        Game,
    }

    internal interface ISceneLoader {
        /// <summary>
        /// Returns loading progress in [0, 1]
        /// </summary>
        float Progress { get; }

        bool IsLoading { get; }

        /// <summary>
        /// Loads next scene
        /// </summary>
        void GoToScene(Scene scene);


        void LoadNextScene();
        IEnumerator LoadLevelAdditive(int number);
    }
}