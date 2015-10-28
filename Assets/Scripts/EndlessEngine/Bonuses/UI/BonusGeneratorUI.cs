// Created 28.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 16:27

namespace Assets.Scripts.EndlessEngine.Bonuses.UI {
    #region References

    using System;
    using Assets.Scripts.Engine.Extensions;
    using Ground;
    using Gameplay.Bonuses.UI;
    using Engine;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class BonusGeneratorUI : MonoBehaviourBase, IBonusGeneratorUI {
        [SerializeField]
        private Transform _bonusesContainer;

        private IGroundGenerator _groundGenerator;

        public void Add(BonusUI bonus) {
            bonus.transform.SetParent(_bonusesContainer);
            bonus.transform.position = transform.position;
            bonus.transform.SetLocalZ(0);
            bonus.Collected += OnCollected;
        }

        public event Action<BonusUI> Collected;

        private void OnCollected(BonusUI bonus) {
            var handler = Collected;
            if (handler != null) {
                handler.Invoke(bonus);
            }
        }

        [PostInject]
        public void Inject(IGroundGenerator groundGenerator, IBonusGenerator generator) {
            _groundGenerator = groundGenerator;
        }
    }
}