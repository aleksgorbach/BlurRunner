// Created 23.10.2015
// Modified by  28.01.2016 at 12:40

namespace Assets.Scripts.UI.Popups {
    #region References

    using System;

    #endregion

    internal interface IPopup {
        event Action<Popup> Closed;
        void Close();
    }
}