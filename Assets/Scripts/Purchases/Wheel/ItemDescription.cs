// Created 03.11.2015 
// Modified by Gorbach Alex 04.11.2015 at 8:40

namespace Assets.Scripts.Purchases.Wheel {
    #region References

    using Engine;
    using SmartLocalization;
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
        private LanguageManager _language;

        public IInAppItem Item {
            set {
                _name.text = _language.GetTextValue(value.Name.Key);
                _description.text = _language.GetTextValue(value.Description.Key);
                _effect.text = _language.GetTextValue(value.Effect.Key);
            }
        }
    }
}