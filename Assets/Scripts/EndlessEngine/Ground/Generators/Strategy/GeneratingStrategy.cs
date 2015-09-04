using UnityEngine;

namespace Assets.Scripts.EndlessEngine.Ground.Generators.Strategy {
    public delegate void GeneratingDelegate();

    internal abstract class GeneratingStrategy : MonoBehaviour {
        public abstract void Init(GeneratingDelegate generatingMethod);
    }
}