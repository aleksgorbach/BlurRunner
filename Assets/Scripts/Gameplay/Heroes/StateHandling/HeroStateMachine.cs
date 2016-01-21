namespace Assets.Scripts.Gameplay.Heroes.StateHandling {
    #region References

    using System.Collections.Generic;
    using Engine.StateMachines;
    using Engine.StateMachines.States;
    using Engine.StateMachines.Transitions;

    #endregion

    internal enum HeroState {
        Idle,
        Run,
        Jump
    }

    class HeroStateMachine : StateMachine<HeroState> {
        public HeroStateMachine(IDictionary<IState, IList<ITransition>> transitions, IState initialState)
            : base(transitions, initialState) {
        }
    }
}