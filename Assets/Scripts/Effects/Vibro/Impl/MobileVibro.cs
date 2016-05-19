namespace Assets.Scripts.Effects.Vibro.Impl {
    using UnityEngine;

    internal class MobileVibro : IVibroImpl {
        public void Vibrate() {
            Handheld.Vibrate();
        }
    }
}