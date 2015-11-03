// Created 03.11.2015
// Modified by Александр 03.11.2015 at 21:21

namespace Assets.Scripts.UI.Graphics {
    #region References

    using System;
    using System.Linq;
    using UnityEngine;

    #endregion

    public class GraphicsCache : ScriptableObject {
        [SerializeField]
        private Entry[] _cache;

        public Sprite this[string key] {
            get {
                var entry = _cache.FirstOrDefault(x => x.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
                if (entry == null) {
                    return null;
                }
                return entry.Image;
            }
        }

        [Serializable]
        private class Entry {
            public Sprite Image;
            public string Key;
        }
    }
}