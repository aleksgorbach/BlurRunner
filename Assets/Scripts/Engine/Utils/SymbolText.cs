namespace Assets.Scripts.Engine.Utils {
    #region References

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    #endregion

    internal class SymbolText : MonoBehaviourBase {
        private List<GameObject> _currentSymbols;

        [SerializeField]
        private SymbolItem[] _symbols;

        public string Text {
            set {
                foreach (var symbol in _currentSymbols) {
                    Destroy(symbol.gameObject);
                }
                _currentSymbols.Clear();
                var currentPosition = 0f;
                foreach (var c in GetPrefabs(value)) {
                    Debug.Log(c);
                    var obj = Instantiate(c);
                    var rect = obj.GetComponent<RectTransform>();
                    rect.SetParent(transform);
                    rect.anchoredPosition3D = new Vector3(currentPosition, 0, 1.5f);
                    rect.localScale = Vector2.one;
                    currentPosition += rect.sizeDelta.x;
                }
            }
        }

        protected override void Awake() {
            base.Awake();
            _currentSymbols = new List<GameObject>();
        }

        private IEnumerable<GameObject> GetPrefabs(string text) {
            foreach (var c in text) {
                var symbol = _symbols.FirstOrDefault(x => x.Symbol == c);
                if (symbol != null) {
                    yield return symbol.Prefab;
                }
            }
        }

        [Serializable]
        public class SymbolItem {
            public GameObject Prefab;
            public char Symbol;
        }
    }
}