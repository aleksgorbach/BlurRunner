using Assets.Scripts.Gameplay.Heroes;

using UnityEngine;

namespace Assets.Scripts.Gameplay {
    public class Game : MonoBehaviour {

        [SerializeField]
        private Hero _hero;

        private void Start() {
            _hero.StartMoving();
        }
    }
}