// Created 21.01.2016
// Modified by  21.01.2016 at 10:11

namespace Assets.Scripts.Gameplay.Heroes.StateBehaviours {
    #region References

    using System;
    using Engine.Extensions;
    using UnityEngine;

    #endregion

    internal abstract class HeroStateBehaviour : StateMachineBehaviour {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
            base.OnStateEnter(animator, stateInfo, layerIndex);
            OnStateEnter();
        }

        protected virtual void OnStateEnter() {
            StateEntered.SafeInvoke(this, new StateEventArgs());
        }

        public event EventHandler<StateEventArgs> StateEntered;
    }
}