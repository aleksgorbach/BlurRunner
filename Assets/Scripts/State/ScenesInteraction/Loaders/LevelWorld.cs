// Created 16.12.2015
// Modified by  18.12.2015 at 16:22

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

        [SerializeField]
        private Hero _heroPrefab;

        [SerializeField]
        private Transform _startPoint;

        public Camera Camera {
            set { _canvas.worldCamera = value; }
        }

        public Sprite Background {
            get { return _background; }
        }

        public Hero HeroPrefab {
            get { return _heroPrefab; }
        }

        public Transform StartPoint {
            get { return _startPoint; }
        }

        protected override void Awake() {
            _canvas = GetComponent<Canvas>();
        }
    }
}