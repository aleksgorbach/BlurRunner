// Created 26.10.2015 
// Modified by Gorbach Alex 26.10.2015 at 13:47

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using UI;
    using Engine.Pool;
    using UnityEngine;

    #endregion

    internal class GroundGenerator : IGroundGenerator {
        private readonly IObjectPool<GroundBlockUI> _pool;
        private readonly IGroundGeneratorUI _view;

        public GroundGenerator(IObjectPool<GroundBlockUI> pool, IGroundGeneratorUI view) {
            _pool = pool;
            _view = view;
            _view.RemoveBlockNeeded += RemoveBlock;
            _view.NewBlockNeed += CreateBlock;
        }

        public event BlockEventDelegate BlockCreated;
        public event BlockEventDelegate BlockRemoved;

        private void CreateBlock(GroundBlockUI block) {
            var groundBlock = GetCompatibleBlock(block);
            _view.AddBlock(groundBlock);
            OnBlockCreated(groundBlock);
        }

        private void RemoveBlock(GroundBlockUI block) {
            _pool.Release(block);
            _view.RemoveBlock();
            OnBlockRemoved(block);
        }

        private GroundBlockUI GetCompatibleBlock(GroundBlockUI origin) {
            var obj = _pool.Get();
            obj.gameObject.SetActive(true);
            return obj;
        }

        private void OnBlockCreated(GroundBlockUI block) {
            var handler = BlockCreated;
            if (handler != null) {
                handler.Invoke(block);
            }
        }

        private void OnBlockRemoved(GroundBlockUI block) {
            var handler = BlockRemoved;
            if (handler != null) {
                handler.Invoke(block);
            }
        }
    }
}