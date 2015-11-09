﻿// Created 08.11.2015
// Modified by Александр 08.11.2015 at 18:08

namespace Assets.Scripts.EndlessEngine.Decorations {
    #region References

    using System.Collections.Generic;
    using Engine.Factory;
    using Engine.Factory.Strategy;
    using UnityEngine;

    #endregion

    internal class DecorationsFactory : MultipleGameObjectFactory<DecorationItem> {
        [SerializeField]
        private DecorationItem[] _prefabs;

        [SerializeField]
        private DecorationStrategy _strategy;

        protected override ChooseStrategy<DecorationItem> Strategy { get { return _strategy; } }

        protected override IEnumerable<DecorationItem> Items {
            get { return _prefabs; }
        }
    }
}