// Created 28.12.2015
// Modified by  28.12.2015 at 11:22

namespace Assets.Scripts.Services {
    internal abstract class BaseServiceConfig : IServicesConfig {
        public const bool IS_TESTING = true;
        public const bool IS_ADS_ENABLED = false;

        public bool IsTesting {
            get { return IS_TESTING; }
        }

        public abstract string AppodealApiKey { get; }

        public virtual bool IsAdsEnabled {
            get { return IS_ADS_ENABLED; }
        }
    }
}