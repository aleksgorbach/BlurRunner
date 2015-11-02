// Created 28.10.2015 
// Modified by Gorbach Alex 02.11.2015 at 10:07

namespace Assets.Scripts.EndlessEngine.Bonuses.UI {
    #region References

    using System;
    using Engine.Extensions;
    using Gameplay.Bonuses.UI;
    using Ground;
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
            bonus.transform.SetLocalY(UnityEngine.Random.Range(-150, 250));
            bonus.transform.SetLocalZ(0);
            bonus.Collected += OnCollected;
            bonus.Collect += OnCollect;
            _items.Add(bonus);
        }

        public event Action<BonusUI> Collected;
        public event Action<BonusUI> Collect;
        public event Action<BonusUI> RemoveNeeded;

        public void RemoveBonus(BonusUI bonus) {
            _items.Remove(bonus);
            bonus.Collected -= OnCollected;
            bonus.Collect -= OnCollect;
        }

        private void OnCollect(BonusUI bonus) {
            var handler = Collect;
            if (handler != null) {
                handler.Invoke(bonus);
            }
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