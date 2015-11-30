// Created 30.11.2015
// Modified by Александр 30.11.2015 at 22:01

namespace Assets.Scripts.Engine.Factory.ChooseStrategies {
    #region References

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using Pool;
    using UnityEngine;

    #endregion

    internal class CompatibleStrategy<T> : IChooseStrategy<T> where T : class, ICompatible<T> {
        private T _lastChosen = null;

        public T Choose(IEnumerable<T> items) {
            try {
                _lastChosen = _lastChosen == null
                    ? items.Random()
                    : items.Where(item => item.IsCompatibleWith(_lastChosen)).Random();
                return _lastChosen;
            }
            catch (Exception) {
                Debug.Log(_lastChosen);
                return null;
            }
        }
    }
}