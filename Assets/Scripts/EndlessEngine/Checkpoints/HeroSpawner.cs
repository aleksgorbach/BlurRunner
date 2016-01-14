// Created 28.11.2015
// Modified by Александр 16.12.2015 at 21:35

namespace Assets.Scripts.EndlessEngine.Checkpoints {
    #region References

    using Engine;
    using Gameplay.Heroes;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class HeroSpawner : MonoBehaviourBase {
        [Inject]
        private IInstantiator _container;

        [SerializeField]
        private Hero _heroPrefab;

        public Hero Generate() {
            var hero = _container.InstantiatePrefabForComponent<Hero>(_heroPrefab.gameObject);
            hero.transform.SetParent(transform);
            hero.rectTransform.anchoredPosition3D = Vector3.zero;
            return hero;
        }
    }
}