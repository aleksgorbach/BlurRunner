// Created 04.11.2015
// Modified by Александр 08.11.2015 at 18:08

#region References

#endregion

namespace Assets.Scripts.Engine.Factory {
    #region References

    using UnityEngine;

    #endregion

    internal abstract class MultipleGameObjectFactory<T> : AbstractGameObjectFactory<T>
        where T : MonoBehaviour {
        //public interface ISettings {
        //    IEnumerable<T> Prefabs { get; }
        //}
    }
}