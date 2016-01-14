// Created 14.01.2016
// Modified by  14.01.2016 at 9:47

namespace Assets.Scripts.EndlessEngine.Checkpoints {
    #region References

    using DG.Tweening;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class CameraTrigger : Checkpoint {
        private const float MOVING_DURATION = 0.5f;

        #region Visible in inspector

        [SerializeField]
        private float _endPositionY;

        [SerializeField]
        private float _endPositionZ;

        #endregion

        #region Injected dependencies

        #endregion

        [PostInject]
        private void OnInject() {
            Debug.Log("camera injected");
        }

        protected override void OnReached() {
            Camera.main.transform.DOMoveY(_endPositionY, MOVING_DURATION).SetEase(Ease.OutQuad);
            Camera.main.transform.DOMoveZ(_endPositionZ, MOVING_DURATION).SetEase(Ease.OutQuad);
        }
    }
}