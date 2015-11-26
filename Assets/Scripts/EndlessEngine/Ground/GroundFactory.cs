// Created 26.11.2015
// Modified by Александр 26.11.2015 at 20:58

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using System.Linq;
    using Engine.Extensions;
    using Zenject;

    #endregion

    internal class GroundFactory : IGroundFactory {
        [Inject]
        private IInstantiator _container;

        private GroundBlock[] _prefabs;

        public GroundBlock Create(GroundBlock prevBlock = null) {
            GroundBlock prefab;
            if (prevBlock == null) {
                prefab = _prefabs.Random();
            }
            else {
                prefab = _prefabs.Where(block => block.IsCompatibleWith(prevBlock)).Random();
            }
            return _container.InstantiatePrefabForComponent<GroundBlock>(prefab.gameObject);
        }

        public void Init(GroundBlock[] ground) {
            _prefabs = ground;
        }
    }
}