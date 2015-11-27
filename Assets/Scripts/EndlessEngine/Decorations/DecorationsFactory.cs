// Created 10.11.2015
// Modified by  27.11.2015 at 10:48

namespace Assets.Scripts.EndlessEngine.Decorations {
    #region References

    using Engine.Extensions;
    using Engine.Factory;
    using Zenject;

    #endregion

    internal class DecorationsFactory : AbstractGameObjectFactory<Decoration> {
        public Decoration Create() {
            return Container.InstantiatePrefabForComponent<Decoration>(Prefabs.Random().gameObject);
        }
    }
}