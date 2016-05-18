// Created 28.12.2015
// Modified by  28.12.2015 at 14:58

namespace Assets.Scripts.UI.Popups {
    #region References

    using System;

    #endregion

    internal class PopupEventArgs : EventArgs {
        public int OpenedPopupsCount { get; private set; }
        public IPopup Popup { get; private set; }

        public PopupEventArgs(IPopup popup, int openedPopupsCount) {
            Popup = popup;
            OpenedPopupsCount = openedPopupsCount;
        }
    }
}