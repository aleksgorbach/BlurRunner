// Created 28.10.2015
// Modified by  28.12.2015 at 11:15

namespace Assets.Scripts.State.ScenesInteraction.Controllers {
    #region References

    using Engine;
    using Engine.Video;
    using Gameplay;
    using Gameplay.Consts;
    using Levels;
    using PlayerPrefs;
    using Zenject;

    #endregion

    internal class GameController : MonoBehaviourBase {
        private const int INTRO_LEVEL = 0;

        [Inject]
        private ILevel _currentLevel;

        [Inject]
        private IGame _game;

        [Inject(Identifiers.Video.Intro)]
        private string _movieFilename;

        [Inject]
        private IPlayerPrefs _prefs;

        [Inject]
        private IVideoPlatform _videoPlatform;

        [PostInject]
        private void Inject() {
            var wasShowed = _prefs.GetBool(Identifiers.Video.WasShowed);
            if (_currentLevel.Number == INTRO_LEVEL && !wasShowed) {
                _videoPlatform.PlayVideo(_movieFilename);
                _prefs.SaveBool(Identifiers.Video.WasShowed, true);
            }
        }
    }
}