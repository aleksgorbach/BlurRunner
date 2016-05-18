// Created 15.01.2016
// Modified by  15.01.2016 at 8:52

namespace Assets.Scripts.EndlessEngine.Actions {
    #region References

    using System;
    using DG.Tweening;
    using UnityEngine;

    #endregion

    internal class CameraAction : MonoAction {
        private const float MOVING_DURATION = 0.5f;

        #region Visible in inspector

        [SerializeField]
        private float _endPositionY;

        [SerializeField]
        private float _endPositionZ;

        #endregion

        protected virtual Camera Camera {
            get { return Camera.main; }
        }

        private void MoveCamera() {
            Camera.transform.DOMoveY(_endPositionY, MovingDuration).SetEase(Ease.OutQuad);
            Camera.transform.DOMoveZ(_endPositionZ, MovingDuration).SetEase(Ease.OutQuad);
        }

        public override Action Action {
            get { return MoveCamera; }
        }

        protected virtual float MovingDuration {
            get { return MOVING_DURATION; }
        }
    }
}