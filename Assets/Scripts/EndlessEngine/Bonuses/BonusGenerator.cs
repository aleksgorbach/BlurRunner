// Created 28.10.2015 
// Modified by Gorbach Alex 11.11.2015 at 14:32

namespace Assets.Scripts.EndlessEngine.Bonuses {
    #region References

    using System;
    using Engine.Extensions;
    using Engine.Pool;
    using Gameplay.Bonuses;
    using Strategy;
    using UnityEngine;

    #endregion

    internal class BonusGenerator : HidingItemGenerator<Bonus>, IBonusGenerator {
        [SerializeField]
        private Transform _bonusesContainer;

        [SerializeField]
        private BonusesPool _pool;

        [SerializeField]
        private Position _position;

        [SerializeField]
        private AbstractStrategy _strategy;

        protected override GameObjectPool<Bonus> Pool {
            get {
                return _pool;
            }
        }

        public event Action<int> ScoreChanged;

        private void Add() {
            if (!CanGenerate) {
                return;
            }
            var bonus = Create();
            bonus.gameObject.SetActive(true);
            bonus.transform.SetParent(_bonusesContainer);
            bonus.transform.position = transform.position;
            bonus.transform.SetLocalY(UnityEngine.Random.Range(_position.Min, _position.Max));
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

        protected override void Awake() {
            base.Awake();
            _strategy.NeedGenerate += Add;
        }

        [Serializable]
        public class Position {
            public float Min;
            public float Max;
        }
    }
}