namespace Assets.Scripts.Effects.Vibro {
    using Impl;
    using Settings;

    internal class VibroManager : EffectsManager {
        private readonly IVibroImpl _impl;

        public VibroManager(ISetting setting, IVibroImpl impl) : base(setting) {
            _impl = impl;
        }

        protected override void PlayEffect(IEffectParameters parameters) {
            _impl.Vibrate();
        }
    }
}