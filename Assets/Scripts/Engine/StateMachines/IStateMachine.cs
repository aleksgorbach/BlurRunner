namespace Assets.Scripts.Engine.StateMachines {
    #region References

    using States;
    using Transitions.Conditions;

    #endregion

    interface IStateMachine<T> {
        IState CurrentState { get; }
        void ApplyAction(ICondition condition);
    }
}