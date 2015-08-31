namespace Assets.Scripts.Engine.Factory {
    internal interface IFactory<out T> {
        T Create();
    }
}