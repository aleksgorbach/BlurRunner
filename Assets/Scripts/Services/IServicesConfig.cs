namespace Assets.Scripts.Services {
    interface IServicesConfig {
        bool IsTesting { get; }
        string AppodealApiKey { get; }
        bool IsAdsEnabled { get; }
    }
}