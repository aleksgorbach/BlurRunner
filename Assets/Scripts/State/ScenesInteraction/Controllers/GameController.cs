// Created 28.10.2015
// Modified by  23.11.2015 at 10:57

namespace Assets.Scripts.State.ScenesInteraction.Controllers {
    #region References

    using Engine;
    using Gameplay;
    using Levels.Storage;
    using Zenject;

    #endregion

    internal class GameController : MonoBehaviourBase {
        [PostInject]
        private void Inject(IGame game, ILevelStorage levelStorage) {
            game.StartLevel(levelStorage.CurrentLevel);
        }
    }
}