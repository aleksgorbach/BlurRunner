// Created 27.11.2015
// Modified by  30.11.2015 at 13:52

namespace Assets.Scripts.Engine {
    #region References

    using System.Collections.Generic;
    using EndlessEngine;
    using Factory;

    #endregion

    internal abstract class AbstractGenerator<T> : MonoBehaviourBase, IGenerator<T> where T : MonoBehaviourBase {
        private List<T> _items = new List<T>();

        protected abstract AbstractGameObjectFactory<T> Factory { get; }
        protected abstract IChooseStrategy<T> Strategy { get; }


        public virtual void Generate(float length, T[] prefabs) {
            Factory.Init(prefabs, Strategy);
        }

        protected void AddItem(T item) {
            _items.Add(item);
        }

        protected void RemoveItem(T item) {
            _items.Remove(item);
        }
    }
}