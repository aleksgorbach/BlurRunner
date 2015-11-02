// Created 28.10.2015 
// Modified by Gorbach Alex 02.11.2015 at 10:04

namespace Assets.Scripts.Gameplay.Bonuses.UI {
    #region References

    using System;

    #endregion

    internal interface IBonusUI {
        event Action<BonusUI> Collected;
        event Action<BonusUI> Collect;
    }
}