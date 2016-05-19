namespace Assets.Scripts.Engine.UrlHandlers {
    using UnityEngine;

    class DefaultUrlHandler : IUrlHandler {
        public void OpenURL(string url) {
            Application.OpenURL(url);
        }
    }
}
