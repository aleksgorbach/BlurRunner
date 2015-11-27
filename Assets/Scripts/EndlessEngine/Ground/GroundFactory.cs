// Created 10.11.2015
// Modified by  27.11.2015 at 9:17

namespace Assets.Scripts.EndlessEngine.Ground {
    #region References

    using System.Linq;
    using Engine.Extensions;
    using Engine.Factory;
    using Zenject;

    #endregion

    internal class GroundFactory : AbstractGameObjectFactory<GroundBlock>, IGroundFactory {
        public GroundBlock Create(GroundBlock prevBlock = null) {
            var prefab = prevBlock == null
                ? Prefabs.Random()
                : Prefabs.Where(block => block.IsCompatibleWith(prevBlock)).Random();
            return Container.InstantiatePrefabForComponent<GroundBlock>(prefab.gameObject);
        }
    }
}