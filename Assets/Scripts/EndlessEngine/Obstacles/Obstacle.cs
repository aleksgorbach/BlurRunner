// Created 20.11.2015
// Modified by  24.12.2015 at 11:06

namespace Assets.Scripts.EndlessEngine.Obstacles {
    #region References

    using Engine;
    using Gameplay.Obstacles;
    using UnityEngine;

    #endregion

    internal class Obstacle : MonoBehaviourBase, IDanger {
        [SerializeField]
        private int _damage;

        public int Damage {
            get { return _damage; }
        }
    }
}