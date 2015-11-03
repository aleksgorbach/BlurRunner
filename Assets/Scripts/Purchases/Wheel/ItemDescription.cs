// Created 03.11.2015 
// Modified by Gorbach Alex 03.11.2015 at 15:02

namespace Assets.Scripts.Purchases.Wheel {
    #region References

    using Localization.Localizators;
    using Engine;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class ItemDescription : MonoBehaviourBase {
        [SerializeField]
        private Text _name;

        [SerializeField]
        private Text _description;

        [SerializeField]
        private Text _effect;

        [Inject]
        private ILocalizator _localizator;

        public IInAppItem Item {
            set {
                _name.text = _localizator.Localize(value.Name);
                _description.text = _localizator.Localize(value.Description);
                _effect.text = _localizator.Localize(value.Effect);
            }
        }
    }
}