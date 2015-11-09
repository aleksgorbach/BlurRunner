// Created 09.11.2015 
// Modified by Gorbach Alex 09.11.2015 at 10:42

namespace Assets.Scripts.EndlessEngine {
    #region References

    using Engine.Pool;

    #endregion

    internal abstract class SolidItem<T> : HidingItem<T>, ICompatible<T> {
        public float Edge {
            get {
                return transform.position.x + rectTransform.sizeDelta.x;
            }
        }

        public abstract bool IsCompatibleWith(T other);
    }
}