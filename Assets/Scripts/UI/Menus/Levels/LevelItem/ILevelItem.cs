// Created 22.10.2015
// Modified by  27.11.2015 at 12:00

namespace Assets.Scripts.UI.Menus.Levels.LevelItem {
    #region References

    using State.Levels;

    #endregion

    internal delegate void LevelChoosedDelegate(ILevel level);

    internal interface ILevelItem {
        ILevel Level { set; }
        event LevelChoosedDelegate LevelChoosed;
    }
}