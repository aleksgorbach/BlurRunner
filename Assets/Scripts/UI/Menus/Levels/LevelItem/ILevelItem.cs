// Created 15.10.2015
// Modified by Александр 20.10.2015 at 18:57

namespace Assets.Scripts.UI.Menus.Levels.LevelItem {
    #region References

    using State.Levels;
    using UnityEngine;

    #endregion

    internal delegate void LevelChoosedDelegate(ILevel level);

    internal interface ILevelItem {
        Vector2 Size { get; }
        Transform Transform { get; }
        ILevel Level { get; set; }
        event LevelChoosedDelegate LevelChoosed;
    }
}