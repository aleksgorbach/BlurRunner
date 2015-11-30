// Created 28.10.2015
// Modified by  30.11.2015 at 13:52

namespace Assets.Scripts.EndlessEngine.Bonuses {
    #region References

    using System;
    using Engine;
    using Engine.Factory;
    using Gameplay.Bonuses;
    using UnityEngine;
    using Zenject;
    using Random = UnityEngine.Random;

    #endregion

    internal class Bonuses : RandomDistanceGenerator<Bonus>, IBonuses {
        [Inject]
        private AbstractGameObjectFactory<Bonus> _factory;

        [SerializeField]
        private Position _position;

        [Inject]
        private IChooseStrategy<Bonus> _strategy;

        protected override AbstractGameObjectFactory<Bonus> Factory {
            get { return _factory; }
        }

        protected override IChooseStrategy<Bonus> Strategy {
            get { return _strategy; }
        }


        public event Action<int> ScoreChanged;

        protected override void InitItem(Bonus item, float currentXPos) {
            item.rectTransform.anchoredPosition3D = new Vector3(currentXPos,
                Random.Range(_position.Min, _position.Max), 0);
            item.Collected += OnCollected;
            item.EndCollected += OnEndCollected;
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