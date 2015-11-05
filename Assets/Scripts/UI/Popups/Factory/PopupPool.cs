// Created 23.10.2015 
// Modified by Gorbach Alex 05.11.2015 at 10:30

namespace Assets.Scripts.UI.Popups.Factory {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    #endregion

    internal class PopupPool {
        private readonly ISettings _settings;

        public PopupPool(ISettings settings) {
            _settings = settings;
        }

        public Popup Get<T>() where T : Popup {
            var prefab = _settings.Prefabs.OfType<T>().FirstOrDefault();
            var obj = Object.Instantiate(prefab.gameObject);
            var popup = obj.GetComponent<T>();
            return popup;
        }

        public void Release(Popup popup) {
            Object.Destroy(popup.gameObject);
        }

        public interface ISettings {
            IEnumerable<Popup> Prefabs { get; }
        }
    }
}