namespace Assets.Scripts.Settings {
    public enum Setting {
        Vibro,
        Sound
    }

    interface ISettingsManager {
        ISetting this[Setting setting] { get; }
    }

    interface ISetting {
        bool IsEnabled { get; set; }
    }
}