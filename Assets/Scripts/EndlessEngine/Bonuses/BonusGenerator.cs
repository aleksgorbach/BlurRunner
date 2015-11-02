// Created 02.11.2015
// Modified by Александр 02.11.2015 at 20:37

namespace Assets.Scripts.EndlessEngine.Bonuses {
    #region References

    using System;
    using Engine.Extensions;
    using Gameplay.Bonuses;
    using Strategy;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class BonusGenerator : HidingItemGenerator<Bonus>, IBonusGenerator {
        [SerializeField]
        private Transform _bonusesContainer;

        [Inject]
        private IBonusStrategy _strategy;

        public event Action<Bonus> BeginCollect;
        public event Action<Bonus> EndCollect;
        public event Action<Bonus> Removed;

        private void Add() {
            var bonus = Create();
            bonus.gameObject.SetActive(true);
            bonus.transform.SetParent(_bonusesContainer);
            bonus.transform.position = transform.position;
            bonus.transform.SetLocalY(UnityEngine.Random.Range(-150, 250));
            bonus.transform.SetLocalZ(0);
            bonus.BeginCollect += OnBeginCollect;
            bonus.EndCollect += OnEndCollect;
            _items.Add(bonus);
        }

        private void OnEndCollect(Bonus bonus) {
            var handler = EndCollect;
            if (handler != null) {
                handler.Invoke(bonus);
            }
            Remove(bonus);
        }

        protected override void OnRemove(Bonus bonus) {
            bonus.BeginCollect -= OnBeginCollect;
            bonus.EndCollect -= OnEndCollect;
            var handler = Removed;
            if (handler != null) {
                handler.Invoke(bonus);
            }
        }

        private void OnBeginCollect(Bonus bonus) {
            var handler = BeginCollect;
            if (handler != null) {
                handler.Invoke(bonus);
            }
        }

        [PostInject]
        private void PostInject() {
            _strategy.BonusNeed += Add;
        }
    }
}