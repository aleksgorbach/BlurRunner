// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 10:34

namespace Assets.Scripts.EndlessEngine.Background {
    #region References

    using Engine.Pool;
    using UnityEngine;

    #endregion

    internal class BackgroundGenerator : SolidGenerator<HillItem> {
        [SerializeField]
        private BackgroundPool _pool;

        protected override GameObjectPool<HillItem> Pool {
            get {
                return _pool;
            }
        }
    }
}