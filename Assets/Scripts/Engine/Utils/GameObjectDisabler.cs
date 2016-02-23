namespace Assets.Scripts.Engine.Utils {
    #region References

    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using UnityEngine.UI;

    #endregion

    class GameObjectDisabler : MonoBehaviourBase {
        [SerializeField]
        private Transform _containerToWatch;

        [SerializeField]
        private float _watchingInterval = 2;

        private IEnumerable<GameObject> _children;

        protected override void Start() {
            base.Start();
            _children = _containerToWatch.GetComponentsInChildren<Image>().Select(x => x.gameObject);
            StartCoroutine(WatchingCoroutine());
        }

        private IEnumerator WatchingCoroutine() {
            foreach (var c in _children.Where(x => x.transform.position.x < transform.position.x)) {
                c.SetActive(false);
            }
            yield return new WaitForSeconds(_watchingInterval);
            StartCoroutine(WatchingCoroutine());
        }
    }
}