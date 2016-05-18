// Created 28.01.2016
// Modified by  28.01.2016 at 12:41

namespace Assets.Scripts.UI.Menus.Levels {
    #region References

    using Popups.Controller;
    using State.Levels;
    using Zenject;

    #endregion

    internal class InGameLevelChoosingMenu : LevelsChoosingMenu {
        [Inject]
        private IPopupController _popupController;

        protected override void GoToGame(ILevel level) {
            base.GoToGame(level);
            _popupController.Close();
        }
    }
}