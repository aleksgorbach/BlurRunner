// Created 22.10.2015
// Modified by  27.11.2015 at 12:10

namespace Assets.Scripts.UI.Menus.Levels {
    #region References

    using LevelItem;

    #endregion

    internal interface ILevelChoosingMenu {
        event LevelChoosedDelegate LevelChoosed;
    }
}