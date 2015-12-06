// Created 26.11.2015
// Modified by Александр 06.12.2015 at 18:29

namespace Assets.Scripts.State.ScenesInteraction.Controllers {
    #region References

    using Engine;
    using Engine.Video;
    using Gameplay;
    using Gameplay.Consts;
    using Levels;
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
        private IVideoPlatform _videoPlatform;

        [PostInject]
        private void Inject() {
            if (_currentLevel.Number == INTRO_LEVEL) {
                _videoPlatform.PlayVideo(_movieFilename);
            }
            _game.StartLevel(_currentLevel);
        }
    }
}