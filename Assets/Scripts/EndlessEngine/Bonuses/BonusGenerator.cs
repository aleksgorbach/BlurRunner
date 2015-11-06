// Created 28.10.2015 
// Modified by Gorbach Alex 06.11.2015 at 14:31

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
        private IGeneratingStrategy _strategy;

        public event Action<int> ScoreChanged;

        private void Add() {
            if (!CanGenerate) {
                return;
            }
            var bonus = Create();
            bonus.gameObject.SetActive(true);
            bonus.transform.SetParent(_bonusesContainer);
            bonus.transform.position = transform.position;
            bonus.transform.SetLocalY(UnityEngine.Random.Range(-150, 250));
            bonus.transform.SetLocalZ(0);
            bonus.Collected += OnCollected;
            bonus.EndCollected += OnEndCollected;
            Add(bonus);
        }

        private void OnEndCollected(Bonus bonus) {
            Remove(bonus);
        }

        protected override void OnRemove(Bonus bonus) {
            bonus.Collected -= OnCollected;
            bonus.EndCollected -= OnEndCollected;
        }

        private void OnCollected(Bonus bonus) {
            var handler = ScoreChanged;
            if (handler != null) {
                handler.Invoke(bonus.Points);
            }
        }

        [PostInject]
        private void PostInject() {
            _strategy.NeedGenerate += Add;
        }
    }
}