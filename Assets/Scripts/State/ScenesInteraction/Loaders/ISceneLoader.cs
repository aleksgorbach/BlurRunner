// Created 22.10.2015
// Modified by  24.12.2015 at 14:50

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using System.Collections;

    #endregion

    internal enum Scene {
        Logo,
        LevelChoose,
        Shop,
        Game
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


        IEnumerator LoadLevelAdditive(int number);
    }
}