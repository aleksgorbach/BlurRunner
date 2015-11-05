// Created 05.11.2015 
// Modified by Gorbach Alex 05.11.2015 at 9:56

namespace Assets.Scripts.State.ScenesInteraction.Controllers {
    #region References

    using Engine;
    using Loaders;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class LevelsController : MonoBehaviourBase {
        [Inject]
        private ISceneLoader _sceneLoader;

        [SerializeField]
        private Button _openShopButton;

        protected override void Awake() {
            base.Awake();
            _openShopButton.onClick.AddListener(OpenShop);
        }

        private void OpenShop() {
            _sceneLoader.GoToScene(Scene.Shop);
        }
    }
}