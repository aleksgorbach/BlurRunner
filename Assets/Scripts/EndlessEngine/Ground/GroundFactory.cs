// Created 10.11.2015
// Modified by  23.11.2015 at 12:57

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using System.Collections.Generic;
    using Engine.Factory;
    using Engine.Factory.Strategy;
    using UnityEngine;

    #endregion

    internal class GroundFactory : AbstractGameObjectFactory<GroundBlock> {
        [SerializeField]
        private GroundBlock[] _prefabs;

        [SerializeField]
        private GroundStrategy _strategy;

        protected override ChooseStrategy<GroundBlock> Strategy {
            get { return _strategy; }
        }

        protected override IEnumerable<GroundBlock> Items {
            get { return _prefabs; }
        }

        protected override void Start() {
            base.Start();
            OnLoaded();
        }
    }
}