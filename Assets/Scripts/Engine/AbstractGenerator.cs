// Created 27.11.2015
// Modified by  27.11.2015 at 14:48

namespace Assets.Scripts.Engine {
    #region References

    using System.Collections.Generic;

    #endregion

    internal abstract class AbstractGenerator<T> : MonoBehaviourBase where T : MonoBehaviourBase {
        private List<T> _items = new List<T>();


        public abstract void Generate(float length, T[] prefabs);

        protected void AddItem(T item) {
            _items.Add(item);
        }

        protected void RemoveItem(T item) {
            _items.Remove(item);
        }
    }
}