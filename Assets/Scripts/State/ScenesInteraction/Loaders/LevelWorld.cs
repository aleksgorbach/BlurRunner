// Created 15.12.2015
// Modified by Александр 15.12.2015 at 21:14

namespace Assets.Scripts.State.ScenesInteraction.Loaders {
    #region References

    using Engine;
    using UnityEngine;

    #endregion

    [RequireComponent(typeof (Canvas))]
    internal class LevelWorld : MonoBehaviourBase {
        private Canvas __canvas;

        public Camera Camera {
            set { __canvas.worldCamera = value; }
        }

        protected override void Awake() {
            __canvas = GetComponent<Canvas>();
        }
    }
}