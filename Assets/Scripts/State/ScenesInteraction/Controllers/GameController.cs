// Created 27.10.2015
// Modified by Александр 27.10.2015 at 21:23

namespace Assets.Scripts.State.ScenesInteraction.Controllers {
    #region References

    using Engine;
    using Gameplay;
    using Levels.Storage;
    using Progress.Storage;
    using Zenject;

    #endregion

    internal class GameController : MonoBehaviourBase {
        [PostInject]
        private void Inject(IGame game, ILevelStorage levelStorage, IProgressStorage progressStorage) {
            game.StartLevel(levelStorage[progressStorage.CurrentLevel]);
        }
    }
}