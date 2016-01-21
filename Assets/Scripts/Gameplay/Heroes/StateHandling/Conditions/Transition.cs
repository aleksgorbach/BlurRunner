namespace Assets.Scripts.Gameplay.Heroes.StateHandling.Transitions {
    using Engine.StateMachines.States;
    using Engine.StateMachines.Transitions;
    using Engine.StateMachines.Transitions.Conditions;

    class Transition : ITransition {
        private readonly IState _endState;

        public Transition(ICondition condition, IState endState) {
            _endState = endState;
            Condition = condition;
        }

        public ICondition Condition { get; private set; }
        public IState Execute() {
            _endState.Execute();
            return _endState;
        }
    }
}
