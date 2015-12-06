// Created 06.12.2015
// Modified by Александр 06.12.2015 at 18:17

namespace Assets.Scripts.Engine.Video {
    #region References

    using UnityEngine;

    #endregion

    internal class MobileVideoPlatform : IVideoPlatform {
        public void PlayVideo(string filename) {
            Handheld.PlayFullScreenMovie(filename);
        }
    }
}