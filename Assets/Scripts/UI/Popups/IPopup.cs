// Created 23.10.2015 
// Modified by Gorbach Alex 06.11.2015 at 9:46

namespace Assets.Scripts.UI.Popups {
    #region References

    using System;

    #endregion

    internal interface IPopup {
        event Action<IPopup> Closed;
    }
}