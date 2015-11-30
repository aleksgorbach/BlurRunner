// Created 30.11.2015
// Modified by  30.11.2015 at 13:51

namespace Assets.Scripts.EndlessEngine {
    internal interface IGenerator<T> {
        void Generate(float length, T[] prefabs);
    }
}