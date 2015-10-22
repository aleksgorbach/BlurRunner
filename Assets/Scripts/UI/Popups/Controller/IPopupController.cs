// Created 22.10.2015
// Modified by Александр 22.10.2015 at 20:24

namespace Assets.Scripts.UI.Popups.Controller {
    internal interface IPopupController {
        IPopup Show<TPopup>() where TPopup : Popup;
        void Close();
    }
}