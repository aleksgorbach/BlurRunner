// Created 23.10.2015
// Modified by  21.01.2016 at 10:57

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using Engine.Input;
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