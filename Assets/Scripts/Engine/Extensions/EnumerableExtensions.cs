// Created 20.10.2015 
// Modified by Gorbach Alex 28.10.2015 at 13:03

#region References

using System.Collections.Generic;
using System.Linq;

#endregion

namespace Assets.Scripts.Engine.Extensions {
    internal static class EnumerableExtensions {
        public static T Random<T>(this IEnumerable<T> items) where T : class {
            var list = items.ToList();
            var index = UnityEngine.Random.Range(0, list.Count);
            if (index >= list.Count) {
                return null;
            }
            return list[index];
        }
    }
}