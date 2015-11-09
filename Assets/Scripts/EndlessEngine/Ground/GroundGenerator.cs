// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 10:29

#region References

#endregion

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using Engine.Pool;
    using UnityEngine;

    #endregion

    internal class GroundGenerator : SolidGenerator<GroundBlock>, IGroundGenerator {
        [SerializeField]
        private GroundPool _pool;

        protected override GameObjectPool<GroundBlock> Pool {
            get {
                return _pool;
            }
        }
    }
}