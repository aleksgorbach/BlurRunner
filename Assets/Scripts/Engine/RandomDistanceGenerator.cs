// Created 30.11.2015
// Modified by  30.11.2015 at 11:38

namespace Assets.Scripts.Engine {
    #region References

    using EndlessEngine.Strategy;
    using UnityEngine;

    #endregion

    internal abstract class RandomDistanceGenerator<T> : AbstractGenerator<T> where T : MonoBehaviourBase {
        [SerializeField]
        private AbstractStrategy _strategy;

        public override void Generate(float length, T[] prefabs) {
            base.Generate(length, prefabs);
            var currentPos = _strategy.DistanceToGenerate;
            while (currentPos < length) {
                var item = Factory.Create();
                AddItem(item);
                item.transform.SetParent(transform);
                InitItem(item, currentPos);
                currentPos += _strategy.DistanceToGenerate;
            }
        }

        protected virtual void InitItem(T item, float currentXPos) {
            item.rectTransform.anchoredPosition3D = new Vector3(currentXPos, 0, 0);
        }
    }
}