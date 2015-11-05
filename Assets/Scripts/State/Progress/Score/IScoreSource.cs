// Created 05.11.2015
// Modified by Александр 05.11.2015 at 20:03

namespace Assets.Scripts.State.Progress.Score {
    using System;

    internal interface IScoreSource {
        event Action<int> ScoreChanged;
    }
}