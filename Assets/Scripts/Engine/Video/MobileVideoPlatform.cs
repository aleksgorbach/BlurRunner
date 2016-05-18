// Created 07.12.2015
// Modified by  14.12.2015 at 14:50

namespace Assets.Scripts.Engine.Video {
    #region References

    using UnityEngine;

    #endregion

    internal class MobileVideoPlatform : IVideoPlatform {
        public void PlayVideo(string filename) {
#if UNITY_ANDROID
            Handheld.PlayFullScreenMovie(filename, Color.black, FullScreenMovieControlMode.Hidden);
#endif
        }
    }
}