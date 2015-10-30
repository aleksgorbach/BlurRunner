// Created 28.10.2015 
// Modified by Gorbach Alex 30.10.2015 at 15:03

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

    internal class BonusGeneratorUI : HidingItemGenerator<BonusUI>, IBonusGeneratorUI {
        [SerializeField]
        private Transform _bonusesContainer;

        private IGroundGenerator _groundGenerator;

        public override void Add(BonusUI bonus) {
            base.Add(bonus);
            bonus.transform.SetParent(_bonusesContainer);
            bonus.transform.position = transform.position;
            bonus.transform.SetLocalZ(0);
            bonus.Collected += OnCollected;
            _items.Add(bonus);
        }

        public event Action<BonusUI> Collected;
        public event Action<BonusUI> RemoveNeeded;

        public void RemoveBonus(BonusUI bonus) {
            _items.Remove(bonus);
            bonus.Collected -= OnCollected;
        }

        protected override void OnItemHide(BonusUI item) {
            OnRemoveNeeded(item);
        }

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

        private void OnRemoveNeeded(BonusUI item) {
            var handler = RemoveNeeded;
            if (handler != null) {
                handler.Invoke(item);
            }
        }
    }
}