// Created 12.11.2015
// Modified by  30.11.2015 at 11:06

namespace Assets.Scripts.UI.Popups.Factory {
    #region References

    using Engine.Factory;
    using Zenject;

    #endregion

    internal class PopupFactory : AbstractGameObjectFactory<Popup> {
        [Inject]
        private Popup[] _prefabs;

        [Inject]
        private PopupStrategy _strategy;

        [PostInject]
        private void PostInject() {
            Init(_prefabs, _strategy);
        }

        public Popup Create<T>() where T : Popup {
            _strategy.SetType<T>();
            return Create();
        }
    }
}