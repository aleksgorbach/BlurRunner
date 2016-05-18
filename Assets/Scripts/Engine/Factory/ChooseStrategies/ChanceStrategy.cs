// Created 14.12.2015
// Modified by  14.12.2015 at 14:36

namespace Assets.Scripts.Engine.Factory.ChooseStrategies {
    #region References

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Random = UnityEngine.Random;

    #endregion

    internal class ChanceStrategy<T> : IChooseStrategy<T> where T : class, IWeightable {
        public T Choose(IEnumerable<T> items) {
            var array = items.ToArray();
            Array.Sort(array, (x, y) => y.Weight.CompareTo(x.Weight));
            var sum = array.Sum(x => x.Weight);
            var rand = Random.Range(0, sum);
            for (var i = 0; i < array.Length; i++) {
                rand -= array[i].Weight;
                if (rand <= 0) {
                    return array[i];
                }
            }
            return null;
        }
    }
}