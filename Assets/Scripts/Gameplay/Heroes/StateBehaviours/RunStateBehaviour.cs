// Created 21.01.2016
// Modified by  21.01.2016 at 12:32

namespace Assets.Scripts.Gameplay.Heroes.StateBehaviours {
    #region References

    using System;
    using Engine.Extensions;
    using UnityEngine;

    #endregion

    internal class RunStateBehaviour : HeroStateBehaviour {
        public event EventHandler<StateEventArgs> Exited;
        private readonly StateEventArgs _args = new StateEventArgs();

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            base.OnStateExit(animator, stateInfo, layerIndex);
            Exited.SafeInvoke(this, _args);
        }
    }
}