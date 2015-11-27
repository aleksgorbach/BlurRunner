// Created 28.10.2015
// Modified by  27.11.2015 at 10:48

namespace Assets.Scripts.EndlessEngine.Bonuses {
    #region References

    using System;
    using Engine;
    using Gameplay.Bonuses;
    using Strategy;
    using UnityEngine;
    using Zenject;
    using Random = UnityEngine.Random;

    #endregion

    internal class Bonuses : AbstractGenerator<Bonus>, IBonuses {
        [Inject]
        private BonusFactory _factory;

        [SerializeField]
        private Position _position;

        [SerializeField]
        private AbstractStrategy _strategy;

        public event Action<int> ScoreChanged;

        public override void Generate(float length, Bonus[] bonuses) {
            _factory.Init(bonuses);
            var currentPos = _strategy.DistanceToGenerate;
            while (currentPos < length) {
                var bonus = _factory.Create();
                AddItem(bonus);
                bonus.transform.SetParent(transform);
                bonus.rectTransform.anchoredPosition3D = new Vector3(currentPos,
                    Random.Range(_position.Min, _position.Max), 0);
                bonus.Collected += OnCollected;
                bonus.EndCollected += OnEndCollected;
                currentPos += _strategy.DistanceToGenerate;
            }
        }

        private void OnEndCollected(Bonus bonus) {
            Remove(bonus);
        }

        private void Remove(Bonus bonus) {
            RemoveItem(bonus);
            bonus.Collected -= OnCollected;
            bonus.EndCollected -= OnEndCollected;
            Destroy(bonus.gameObject);
        }

        private void OnCollected(Bonus bonus) {
            var handler = ScoreChanged;
            if (handler != null) {
                handler.Invoke(bonus.Points);
            }
        }

        [Serializable]
        public class Position {
            public float Max;
            public float Min;
        }
    }
}