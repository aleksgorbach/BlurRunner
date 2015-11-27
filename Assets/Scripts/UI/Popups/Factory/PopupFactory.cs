// Created 12.11.2015
// Modified by  27.11.2015 at 14:01

namespace Assets.Scripts.UI.Popups.Factory {
    #region References

    using System.Linq;
    using Engine.Factory;
    using Zenject;

    #endregion

    internal class PopupFactory : AbstractGameObjectFactory<Popup> {
        [Inject]
        private Popup[] _prefabs;

        public Popup Create<T>() where T : Popup {
            var prefab = Prefabs.OfType<T>().First();
            return Container.InstantiatePrefabForComponent<T>(prefab.gameObject);
        }

        [PostInject]
        private void PostInject() {
            Init(_prefabs);
        }
    }
}