// Created 23.10.2015
// Modified by  28.12.2015 at 14:59

namespace Assets.Scripts.UI.Popups.Controller {
    #region References

    using System;

    #endregion

    internal interface IPopupController {
        event EventHandler<PopupEventArgs> PopupOpened;
        event EventHandler<PopupEventArgs> PopupClosed;
        IPopup Show<TPopup>() where TPopup : Popup;
        void Close();
    }
}