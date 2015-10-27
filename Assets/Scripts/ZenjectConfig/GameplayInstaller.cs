// Created 26.10.2015
// Modified by Александр 27.10.2015 at 21:30

#region References

#endregion

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using System;
    using System.Collections.Generic;
    using EndlessEngine.Ground;
    using EndlessEngine.Ground.Decorations;
    using EndlessEngine.Ground.Decorations.Strategy;
    using EndlessEngine.Ground.Decorations.UI;
    using EndlessEngine.Ground.UI;
    using Engine.Factory;
    using Engine.Factory.Strategy;
    using Engine.Pool;
    using Gameplay;
    using Gameplay.GameState.Manager;
    using Gameplay.GameState.Pause;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class GameplayInstaller : MonoInstaller {
        [SerializeField]
        private readonly int _initialPoolSize = 10;

        [SerializeField]
        private BlockSettings _blockSettings;

        [SerializeField]
        private TreeSettings _treeSettings;

        public override void InstallBindings() {
            Container.Bind<IGame>().ToTransient<Game>();
            Container.Bind<IGameStateManager>().ToSingle<GameStateManager>();
            Container.Bind<IGettingStrategy>().ToTransient<Engine.Factory.Strategy.RandomStrategy>();
            Container.Bind<Camera>().ToSingleInstance(Camera.main);
            Container.Bind<IPauseHandler>().ToSingle<GameStateManager>();
            BindGround();
            BindDecorations();
        }

        private void BindDecorations() {
            Container.Bind<Engine.Factory.IFactory<DecorationItemUI>>()
                .ToTransient<RandomGameObjectFactory<DecorationItemUI>>();
            Container.Bind<RandomGameObjectFactory<DecorationItemUI>.ISettings>().ToInstance(_treeSettings);
            Container.Bind<IDecorationGenerator>().ToSingle<DecorationGenerator>();
            Container.Bind<IDecorationGeneratorUI>().ToInstance(_treeSettings.Generator);
            Container.Bind<IGeneratingStrategy>().ToInstance(_treeSettings.Strategy);
            Container.Bind<IObjectPool<DecorationItemUI>>().ToSingleGameObject<DecorationPool>("DecorationsPool");
            Container.Bind<bool>(GameObjectPool<DecorationItemUI>.CAN_GROW_KEY)
                .ToInstance(true)
                .WhenInjectedInto<DecorationPool>();
            Container.Bind<int>(GameObjectPool<DecorationItemUI>.INITIAL_SIZE_KEY)
                .ToInstance(_initialPoolSize)
                .WhenInjectedInto<DecorationPool>();
        }

        private void BindGround() {
            Container.Bind<Engine.Factory.IFactory<GroundBlockUI>>()
                .ToTransient<RandomGameObjectFactory<GroundBlockUI>>();
            Container.Bind<RandomGameObjectFactory<GroundBlockUI>.ISettings>().ToInstance(_blockSettings);
            Container.Bind<IGroundGenerator>().ToSingle<GroundGenerator>();
            Container.Bind<IGroundGeneratorUI>().ToInstance(_blockSettings.Generator);
            Container.Bind<IObjectPool<GroundBlockUI>>().ToSingleGameObject<GroundPool>("GroundBlocksPool");
            Container.Bind<bool>(GameObjectPool<GroundBlockUI>.CAN_GROW_KEY)
                .ToInstance(true)
                .WhenInjectedInto<GroundPool>();
            Container.Bind<int>(GameObjectPool<GroundBlockUI>.INITIAL_SIZE_KEY)
                .ToInstance(_initialPoolSize)
                .WhenInjectedInto<GroundPool>();
        }

        [Serializable]
        public class BlockSettings : RandomGameObjectFactory<GroundBlockUI>.ISettings {
            [SerializeField]
            private GroundGeneratorUI _generator;

            [SerializeField]
            private GroundBlockUI[] _prefabs;

            public IGroundGeneratorUI Generator {
                get { return _generator; }
            }

            public IEnumerable<GroundBlockUI> Prefabs {
                get { return _prefabs; }
            }
        }

        [Serializable]
        public class TreeSettings : RandomGameObjectFactory<DecorationItemUI>.ISettings {
            [SerializeField]
            private DecorationGeneratorUI _generator;

            [SerializeField]
            private DecorationItemUI[] _prefabs;

            [SerializeField]
            private AbstractStrategy _strategy;

            public AbstractStrategy Strategy {
                get { return _strategy; }
            }

            public IDecorationGeneratorUI Generator {
                get { return _generator; }
            }

            public IEnumerable<DecorationItemUI> Prefabs {
                get { return _prefabs; }
            }
        }
    }
}