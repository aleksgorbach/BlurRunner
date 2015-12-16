// Created 15.12.2015
// Modified by Александр 16.12.2015 at 21:59

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using EndlessEngine.Endpoints;
    using Engine;
    using Gameplay.Heroes;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof (Canvas))]
    internal class LevelWorld : MonoBehaviourBase {
        [SerializeField]
        private Sprite _background;

        private Canvas _canvas;

        private Hero _hero;

        [SerializeField]
        private HeroSpawner _heroSpawner;

        public Camera Camera {
            set { _canvas.worldCamera = value; }
        }

        public Sprite Background {
            get { return _background; }
        }

        public Hero Hero {
            get {
                if (_hero == null) {
                    _hero = _heroSpawner.Generate();
                }
                return _hero;
            }
        }

        protected override void Awake() {
            _canvas = GetComponent<Canvas>();
        }
    }
}