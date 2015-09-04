namespace Assets.Scripts.EndlessEngine.Ground.Generators.Strategy {
    public delegate void GeneratingDelegate();

    internal interface IGeneratingStrategy {
        void Init(GeneratingDelegate generatingMethod);
    }
}