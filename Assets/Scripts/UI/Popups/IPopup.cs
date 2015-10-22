namespace Assets.Scripts.UI.Popups {
    internal delegate void PopupClick(IPopup popup);
    interface IPopup {
        event PopupClick Click;
    }
}
