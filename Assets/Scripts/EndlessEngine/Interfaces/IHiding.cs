namespace Assets.Scripts.EndlessEngine.Interfaces {
    internal delegate void HidingDelegate(IHiding obj);

    internal interface IHiding {
        /// <summary>
        /// Fired when object became invisible
        /// </summary>
        event HidingDelegate BecameInvisible;
    }
}