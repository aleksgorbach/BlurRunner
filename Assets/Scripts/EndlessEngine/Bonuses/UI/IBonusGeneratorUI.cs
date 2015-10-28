// Created 28.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 14:51

namespace Assets.Scripts.EndlessEngine.Bonuses.UI {
    #region References

    using System;
    using Gameplay.Bonuses.UI;

    #endregion

    internal interface IBonusGeneratorUI {
        void Add(BonusUI bonus);

        event Action<BonusUI> Collected;
    }
}