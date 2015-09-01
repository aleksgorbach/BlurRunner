using UnityEngine;

namespace Assets.Scripts.Engine.Physics {
    [RequireComponent(typeof (Rigidbody2D))]
    internal class CenterOfMass : MonoBehaviour {
        [SerializeField] private RectTransform _centerOfMass;

        private void Awake() {
            GetComponent<Rigidbody2D>().centerOfMass = _centerOfMass.anchoredPosition;
        }
    }
}