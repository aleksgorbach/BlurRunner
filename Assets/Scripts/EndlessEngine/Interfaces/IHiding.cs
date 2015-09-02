namespace Assets.Scripts.EndlessEngine.Interfaces {
    internal delegate void HidingDelegate(IHiding obj);

    internal interface IHiding {
        bool IsVisible { get; }
    }
}