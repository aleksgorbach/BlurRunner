// Created 15.10.2015
// Modified by Александр 18.10.2015 at 18:54

namespace Assets.Scripts.UI.Menus.Levels.LevelItem {
    #region References

    using UnityEngine;

    #endregion

    internal interface ILevelItemUI {
        Vector2 Size { get; }
        Transform Transform { get; }
        int Level { get; set; }
    }
}