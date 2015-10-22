// Created 22.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 14:45

namespace Assets.Scripts.UI.Menus.Levels {
    #region References

    using System.Collections.Generic;
    using Assets.Scripts.UI.Menus.Levels.LevelItem;
    using State.Levels;

    #endregion

    internal interface ILevelChoosingMenu {
        IEnumerable<ILevel> Levels { set; }
        event LevelChoosedDelegate LevelChoosed;
    }
}