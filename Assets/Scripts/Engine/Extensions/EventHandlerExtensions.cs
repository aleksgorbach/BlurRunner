namespace Assets.Scripts.Engine.Extensions {
    #region References

    using System;

    #endregion

    public static class EventHandlerExtensions {
        public static void SafeInvoke<T>(this EventHandler<T> handler, object sender, T args) where T : EventArgs {
            if (handler != null) {
                handler.Invoke(sender, args);
            }
        }
    }
}