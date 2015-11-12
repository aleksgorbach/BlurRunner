// Created 12.11.2015 
// Modified by Gorbach Alex 12.11.2015 at 11:23

namespace Assets.Scripts.UI.Popups.Factory {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using Assets.Scripts.Engine.Factory;
    using Assets.Scripts.Engine.Factory.Strategy;
    using Engine;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class PopupFactory : AbstractGameObjectFactory<Popup> {
        [SerializeField]
        private Popup[] _prefabs;

        [SerializeField]
        private PopupStrategy _strategy;

        //[Inject]
        //private IInstantiator _instantiator;

        //public virtual Popup Create<TPopup>() where TPopup : Popup {
        //    var prefab = _prefabs.OfType<TPopup>().FirstOrDefault();
        //    if (prefab == null) {
        //        return null;
        //    }
        //    var created = _instantiator.InstantiatePrefabForComponent<TPopup>(prefab.gameObject);
        //    return created;
        //}
        protected override ChooseStrategy<Popup> Strategy {
            get {
                return _strategy;
            }
        }

        protected override IEnumerable<Popup> Items {
            get {
                return _prefabs;
            }
        }
    }
}