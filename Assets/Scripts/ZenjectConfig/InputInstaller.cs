// Created 23.10.2015 
// Modified by Gorbach Alex 23.10.2015 at 10:21

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using Engine.Input;
    using Engine.Moving;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class InputInstaller : MonoInstaller {
        [SerializeField]
        private InputController _inputController;

        public override void InstallBindings() {
            Container.Bind<IInputController>().ToInstance(_inputController);
        }
    }
}