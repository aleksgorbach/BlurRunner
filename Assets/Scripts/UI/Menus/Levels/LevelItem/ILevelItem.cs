// Created 15.10.2015
// Modified by Александр 01.11.2015 at 17:53

namespace Assets.Scripts.UI.Menus.Levels.LevelItem {
    #region References

    using State.Levels;
    using UnityEngine;

    #endregion

    internal delegate void LevelChoosedDelegate(ILevel level);

    internal interface ILevelItem {
        Vector2 Size { get; }
        Transform Transform { get; }
        ILevel Level { set; }
        event LevelChoosedDelegate LevelChoosed;
    }
}