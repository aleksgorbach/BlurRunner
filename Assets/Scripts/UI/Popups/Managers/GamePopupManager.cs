namespace Assets.Scripts.UI.Popups.Managers {
    using Controller;
    using Engine;
    using Gameplay.Consts;
    using Gameplay.GameState.Manager;
    using Implementations;
    using Zenject;

    internal class GamePopupManager : MonoBehaviourBase {
        [Inject]
        private IPopupController _popupController;

        [PostInject]
        private void Init(IGameStateManager stateManager) {
            stateManager.StateChanged += OnStateChanged;
        }

        private void OnStateChanged(object sender, GameStateChangedArgs e) {
            switch (e.State) {
                case GameState.Paused:
                    _popupController.Show<PausePopup>();
                    break;
                case GameState.Win:
                    _popupController.Show<CompletedPopup>();
                    break;
                case GameState.Lose:
                    _popupController.Show<FailedPopup>();
                    break;
            }
        }
    }
}