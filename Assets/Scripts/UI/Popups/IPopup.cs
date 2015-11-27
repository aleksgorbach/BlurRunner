// Created 23.10.2015
// Modified by  27.11.2015 at 12:14

namespace Assets.Scripts.UI.Popups {
    #region References

    using System;

    #endregion

    internal interface IPopup {
        event Action<Popup> Closed;
    }
}