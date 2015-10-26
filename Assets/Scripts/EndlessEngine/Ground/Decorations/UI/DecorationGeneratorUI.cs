// Created 26.10.2015 
// Modified by Gorbach Alex 26.10.2015 at 14:46

namespace Assets.Scripts.EndlessEngine.Ground.Decorations.UI {
    #region References

    using Ground.UI;
    using Engine;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class DecorationGeneratorUI : MonoBehaviourBase, IDecorationGeneratorUI {
        [Inject]
        private IDecorationGenerator _generator;

        public void Add(DecorationItemUI created, GroundBlockUI block) {
            created.transform.SetParent(transform, false);
            created.transform.localPosition = new Vector2(block.transform.position.x, block.transform.position.y);
        }
    }
}