// Created 16.12.2015
// Modified by  15.01.2016 at 8:42

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using EndlessEngine.Actions;
    using Engine;
    using Gameplay.GameState.StateChangedSources;
    using UnityEngine;

    #endregion

    internal class LevelWorld : MonoBehaviourBase {
        [SerializeField]
        private Canvas _backgroundCanvas;

        [SerializeField]
        private Canvas _foregroundCanvas;

        private LevelEndAction _levelEnd;

        protected override void Awake() {
            base.Awake();
            _levelEnd = FindObjectOfType<LevelEndAction>();
            StartPoint = GameObject.Find("HeroSpawner").transform;
        }

        public Camera ForegroundCamera {
            set { _foregroundCanvas.worldCamera = value; }
        }

        public Camera BackgroundCamera {
            set { _backgroundCanvas.worldCamera = value; }
        }

        public Transform StartPoint { get; private set; }

        public IWinSource EndPoint {
            get { return _levelEnd; }
        }

        public float Length {
            get { return _levelEnd.transform.position.x - StartPoint.transform.position.x; }
        }
    }
}