// Created 22.10.2015 
// Modified by Gorbach Alex 22.10.2015 at 12:44

namespace Assets.Scripts.Engine.Utils.StatedObjects {
    internal abstract class StatedObject : MonoBehaviourBase {
        private bool _state;

        public bool State {
            get {
                return _state;
            }
            set {
                _state = value;
                ChangeState(value);
            }
        }

        protected override void Awake() {
            base.Awake();
            State = false;
        }

        protected abstract void ChangeState(bool isActive);
    }
}