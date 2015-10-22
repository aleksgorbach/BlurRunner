// Created 22.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 12:49

namespace Assets.Scripts.Engine.Utils.StatedObjects {
    #region References

    using UnityEngine;
    using UnityEngine.UI;

    #endregion

    internal class ImageStatesObject : StatedObject {
        [SerializeField]
        private Image _image;

        [Header("Sprites")]
        [SerializeField]
        private Sprite _activeSprite;

        [SerializeField]
        private Sprite _inactiveSprite;

        protected override void ChangeState(bool isActive) {
            _image.sprite = isActive ? _activeSprite : _inactiveSprite;
        }
    }
}