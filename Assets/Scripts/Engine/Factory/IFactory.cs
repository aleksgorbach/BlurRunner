// Created 15.10.2015
// Modified by Александр 22.10.2015 at 20:14

namespace Assets.Scripts.Engine.Factory {
    internal interface IFactory<out T> {
        T Create();
    }
}