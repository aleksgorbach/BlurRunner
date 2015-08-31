using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Engine.Extensions {
    internal static class EnumerableExtensions {
        public static T Random<T>(this IEnumerable<T> items) {
            var list = items.ToList();
            var index = UnityEngine.Random.Range(0, list.Count);
            return list[index];
        }
    }
}