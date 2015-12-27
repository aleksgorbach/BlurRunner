namespace Assets.Scripts.Services {
    abstract class BaseServiceConfig : IServicesConfig {
        public const bool IS_TESTING = true;
        public const bool IS_ADS_ENABLED = true;

        public bool IsTesting {
            get { return IS_TESTING; }
        }

        public abstract string AppodealApiKey { get; }

        public virtual bool IsAdsEnabled {
            get { return IS_ADS_ENABLED; }
        }
    }
}