using Assets.Scripts.EndlessEngine.Interfaces;
using UnityEngine;

namespace Assets.Scripts.EndlessEngine.Ground.UI {
    [RequireComponent(typeof (Collider2D))]
    internal class GroundBlockUI : MonoBehaviour, IHiding {
        public IGroundBlock Block { get; private set; }
        public float Length { get; private set; }

        private void Awake() {
            Length = GetComponent<Collider2D>().bounds.size.x;
        }

        public void Init(IGroundBlock block) {
            Block = block;
        }

        public event HidingDelegate BecameInvisible;

        private void OnBecameInvisible() {
            Debug.Log("Invisible");
            if (BecameInvisible != null) {
                BecameInvisible(this);
            }
        }

        public void OnBecameVisible() {
            Debug.Log("visible");
        }
    }
}