namespace Assets.Scripts.Effects {
    using Settings;

    internal abstract class EffectsManager {
        protected readonly  ISetting Setting;

        protected EffectsManager(ISetting setting) {
            Setting = setting;
        }

        protected abstract void PlayEffect(IEffectParameters parameters);

        public void Play(IEffectParameters parameters) {
            if (!Setting.IsEnabled) {
                return;
            }
            PlayEffect(parameters);
        }
    }

    internal interface IEffectParameters {
    }
}