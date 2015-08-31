using System;

namespace Assets.Scripts.Engine.Pool {
    internal class PoolBusyException<T> : OverflowException {
        public override string Message {
            get { return "There's no free objects in pool of " + typeof (T); }
        }
    }
}