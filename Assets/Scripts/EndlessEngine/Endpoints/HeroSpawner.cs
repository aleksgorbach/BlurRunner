// Created 19.11.2015
// Modified by Александр 19.11.2015 at 21:32

namespace Assets.Scripts.EndlessEngine.Endpoints {
    #region References

    using Engine;
    using UnityEngine;
    using UnityEngine.UI;

    #endregion

    internal class HeroSpawner : MonoBehaviourBase {
        [SerializeField]
        private Transform _container;

        [SerializeField]
        private Image _startPoint;

        public Sprite Sprite {
            set {
                if (value != null) {
                    _startPoint.sprite = value;
                }
                else {
                    _startPoint.gameObject.SetActive(false);
                }
            }
        }

        public Transform Container {
            get { return _container; }
        }
    }
}