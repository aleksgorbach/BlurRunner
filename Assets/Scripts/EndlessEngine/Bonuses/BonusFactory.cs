// Created 10.11.2015
// Modified by  27.11.2015 at 9:17

namespace Assets.Scripts.EndlessEngine.Bonuses {
    #region References

    using Engine.Extensions;
    using Engine.Factory;
    using Gameplay.Bonuses;
    using Zenject;

    #endregion

    internal class BonusFactory : AbstractGameObjectFactory<Bonus> {
        public Bonus Create() {
            return Container.InstantiatePrefabForComponent<Bonus>(Prefabs.Random().gameObject);
        }
    }
}