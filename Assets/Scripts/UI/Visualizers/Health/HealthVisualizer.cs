// Created 03.11.2015
// Modified by  24.12.2015 at 15:08

namespace Assets.Scripts.UI.Visualizers.Health {
    #region References

    using Bonuses;
    using Engine;
    using Gameplay;
    using Gameplay.Heroes;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    #endregion

    internal class HealthVisualizer : MonoBehaviourBase, IHealthVisualizer {
        #region Visible in inspector

        [SerializeField]
        private float _maxProgress;

        [SerializeField]
        private Text _points;

        [SerializeField]
        private Image _progressbar;

        #endregion

        [Inject]
        private IGame _game;

        private float Balanse {
            set {
                _points.text = "" + value;
                _progressbar.fillAmount = value/10f;
            }
        }

        [PostInject]
        private void PostInject() {
            _game.HeroSpawned += OnHeroSpawned;
        }

        private void OnProgressChanged(int currentScore) {
            Balanse = currentScore;
        }

        protected override void OnDestroy() {
            _game.HeroSpawned -= OnHeroSpawned;
        }

        private void OnHeroSpawned(object sender, Hero.HeroSpawnedEventArgs e) {
            e.Hero.HealthChanged += OnHealthChanged;
            Balanse = e.Hero.Health;
        }

        private void OnHealthChanged(float previousHealth, float currentHealth) {
            Balanse = currentHealth;
        }
    }
}