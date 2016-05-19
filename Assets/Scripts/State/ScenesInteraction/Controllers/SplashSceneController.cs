namespace Assets.Scripts.State.ScenesInteraction.Controllers {
    using Engine;
    using Loaders;
    using UnityEngine;
    using Zenject;

    [RequireComponent(typeof (Animator))]
    class SplashSceneController : MonoBehaviourBase {
        private Animator _animator;
        private const string SWIPE_KEY = "swipe";
        private const string MENU_KEY = "menu";

        [Inject]
        private ISceneLoader _sceneLoader;

        protected override void Awake() {
            base.Awake();
            _animator = GetComponent<Animator>();
        }

        public void OnPlayButtonClick() {
            _animator.SetTrigger(MENU_KEY);
        }

        public void OnSceneTransitionEnd() {
            _sceneLoader.GoToScene(Scene.LevelChoose);
        }

        public void OnInitialSwipe() {
            _animator.SetTrigger(SWIPE_KEY);
        }
    }
}