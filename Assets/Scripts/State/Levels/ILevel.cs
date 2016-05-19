// Created 30.11.2015
// Modified by Александр 03.12.2015 at 20:51

namespace Assets.Scripts.State.Levels {
    #region References

    

    #endregion

    internal interface ILevel {
        int Number { get; }
        string Background { get; }
        int HeroAge { get; }
        string HeroPrefab { get; }
        string SceneName { get; }
    }
}