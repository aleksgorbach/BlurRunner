// Created 20.11.2015
// Modified by  27.11.2015 at 13:04

namespace Assets.Scripts.EndlessEngine.Endpoints {
    #region References

    using Engine;
    using Gameplay.Heroes;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class HeroSpawner : MonoBehaviourBase {
        [Inject]
        private IInstantiator _container;

        [SerializeField]
        private Image _startPoint;

        public Hero Generate(Hero prefab) {
            var hero = _container.InstantiatePrefabForComponent<Hero>(prefab.gameObject);
            hero.transform.SetParent(transform);
            hero.rectTransform.anchoredPosition3D = Vector3.zero;
            return hero;
        }
    }
}