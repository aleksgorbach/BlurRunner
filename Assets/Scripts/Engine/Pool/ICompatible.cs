// Created 01.11.2015
// Modified by Александр 01.11.2015 at 20:47

namespace Assets.Scripts.Engine.Pool {
    internal interface ICompatible<in T> {
        bool IsCompatibleWith(T other);
    }
}