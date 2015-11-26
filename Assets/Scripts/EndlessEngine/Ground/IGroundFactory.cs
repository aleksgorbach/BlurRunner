// Created 26.11.2015
// Modified by Александр 26.11.2015 at 19:58

namespace Assets.Scripts.EndlessEngine.Ground {
    internal interface IGroundFactory {
        GroundBlock Create(GroundBlock prevBlock = null);
        void Init(GroundBlock[] ground);
    }
}