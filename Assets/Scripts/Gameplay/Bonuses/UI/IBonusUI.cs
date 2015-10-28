// Created 28.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 14:56

namespace Assets.Scripts.Gameplay.Bonuses.UI {
    #region References

    using System;

    #endregion

    internal interface IBonusUI {
        event Action<BonusUI> Collected;
    }
}