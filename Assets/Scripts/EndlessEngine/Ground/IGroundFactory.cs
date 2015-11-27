// Created 27.11.2015
// Modified by  27.11.2015 at 9:13

namespace Assets.Scripts.EndlessEngine.Ground {
    internal interface IGroundFactory {
        GroundBlock Create(GroundBlock prevBlock = null);
    }
}