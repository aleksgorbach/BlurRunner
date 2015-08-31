namespace Assets.Scripts.Engine.Pool {
    internal interface IObjectPool<T> {
        T Get();
        void Release(T obj);
    }
}