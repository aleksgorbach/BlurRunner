// Created 28.10.2015 
// Modified by Gorbach Alex 02.11.2015 at 9:28

namespace Assets.Scripts.Gameplay.Bonuses {
    internal interface IBonus {
        float Strength { get; }

        void Apply();
    }
}