namespace Assets.Scripts.Engine.StateMachines.Transitions {
    #region References

    using Conditions;
    using States;

    #endregion

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