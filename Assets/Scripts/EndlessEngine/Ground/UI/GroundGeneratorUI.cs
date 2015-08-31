using Assets.Scripts.EndlessEngine.Ground.Generators;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.EndlessEngine.Ground.UI {
    internal class GroundGeneratorUI : MonoBehaviour {
        [Inject] private IGroundGenerator _generator;
    }
}