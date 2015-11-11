// Created 23.10.2015 
// Modified by Gorbach Alex 11.11.2015 at 13:57

namespace Assets.Scripts.UI.Popups.Controller {
    #region References

    using System;

    #endregion

    internal interface IPopupController {
        event Action<IPopup, int> PopupOpened;
        event Action<IPopup, int> PopupClosed;
    }
}