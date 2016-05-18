// Created 28.10.2015
// Modified by Александр 30.11.2015 at 22:07

#region References



#endregion

namespace Assets.Scripts.Engine.Extensions {
    #region References

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal static class EnumerableExtensions {
        public static T Random<T>(this IEnumerable<T> items) where T : class {
            var list = items.ToList();
            var index = UnityEngine.Random.Range(0, list.Count);
            if (index >= list.Count) {
                throw new ArgumentOutOfRangeException();
            }
            return list[index];
        }
    }
}