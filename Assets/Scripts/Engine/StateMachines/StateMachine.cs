namespace Assets.Scripts.Engine.StateMachines {
    #region References

    using System.Collections.Generic;
    using System.Linq;
    using States;
    using Transitions;
    using Transitions.Conditions;

    #endregion

    class StateMachine<T> : IStateMachine<T> {
        private readonly IDictionary<IState, IList<ITransition>> _transitions;

        public StateMachine(IDictionary<IState, IList<ITransition>> transitions, IState initialState) {
            _transitions = transitions;
            CurrentState = initialState;
        }

        public IState CurrentState { get; private set; }

        public void ApplyAction(ICondition condition) {
            var availableTransitions = _transitions[CurrentState];
            var chosenTransition =
                availableTransitions.FirstOrDefault(transition => transition.Condition.Equals(condition));
            if (chosenTransition == null) {
                return;
            }
            CurrentState = chosenTransition.Execute();
        }
    }
}