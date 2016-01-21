namespace Assets.Scripts.Engine.StateMachines.Transitions {
    using Conditions;
    using States;

    #region References

    

    #endregion

    interface ITransition {
        ICondition Condition{ get; }
        IState Execute();
    }
}