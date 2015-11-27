// Created 20.11.2015
// Modified by  27.11.2015 at 9:27

namespace Assets.Scripts.EndlessEngine.Strategy {
    internal class DistanceRandomStrategy : RandomStrategy {
        public override float DistanceToGenerate {
            get { return GetRandomValueWithDistribution(); }
        }
    }
}