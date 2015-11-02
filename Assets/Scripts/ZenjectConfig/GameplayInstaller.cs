// Created 02.11.2015
// Modified by Александр 02.11.2015 at 21:08

#region References

#endregion

namespace Assets.Scripts.ZenjectConfig {
    #region References

    using System;
    using System.Collections.Generic;
    using EndlessEngine.Bonuses;
    using EndlessEngine.Bonuses.Strategy;
    using EndlessEngine.Decorations;
    using EndlessEngine.Decorations.Strategy;
    using EndlessEngine.Ground;
    using EndlessEngine.Ground.UI;
    using Engine.Factory;
    using Engine.Factory.Strategy;
    using Engine.Pool;
    using Gameplay;
    using Gameplay.Bonuses;
    using Gameplay.GameState.Manager;
    using Gameplay.GameState.Pause;
    using UnityEngine;
    using Zenject;

    #endregion

    internal class GameplayInstaller : MonoInstaller {
        private readonly int _initialPoolSize = 10;

        [SerializeField]
        private BlockSettings _blockSettings;

        [SerializeField]
        private BonusSettings _bonusesSettings;

        [SerializeField]
        private DecorationsSettings _decorationsSettings;

        [SerializeField]
        private Game _game;

        public override void InstallBindings() {
            Container.Bind<IGame>().ToInstance(_game);
            Container.Bind<IGameStateManager>().ToSingle<GameStateManager>();
            Container.Bind<Camera>().ToSingleInstance(Camera.main);
            Container.Bind<IPauseHandler>().ToSingle<GameStateManager>();
            BindGround();
            BindDecorations();
            BindBonuses();
        }

        private void BindBonuses() {
            Container.Bind<Engine.Factory.IFactory<Bonus>>().ToTransient<RandomGameObjectFactory<Bonus>>();
            Container.Bind<IBonusStrategy>().ToInstance(_bonusesSettings.Strategy);
            Container.Bind<IBonusGenerator>().ToInstance(_bonusesSettings.Generator);
            Container.Bind<IPoolStrategy<Bonus>>().ToTransient<RandomStrategy<Bonus>>();
            Container.Bind<RandomGameObjectFactory<Bonus>.ISettings>().ToInstance(_bonusesSettings);
            Container.Bind<IObjectPool<Bonus>>().ToSingleGameObject<BonusesPool>("BonusesPool");
            Container.Bind<bool>(GameObjectPool<Bonus>.CAN_GROW_KEY).ToInstance(true).WhenInjectedInto<BonusesPool>();
            Container.Bind<int>(GameObjectPool<Bonus>.INITIAL_SIZE_KEY)
                .ToInstance(_initialPoolSize)
                .WhenInjectedInto<BonusesPool>();
        }

        private void BindDecorations() {
            Container.Bind<Engine.Factory.IFactory<DecorationItem>>()
                .ToTransient<RandomGameObjectFactory<DecorationItem>>();
            Container.Bind<RandomGameObjectFactory<DecorationItem>.ISettings>().ToInstance(_decorationsSettings);
            Container.Bind<IPoolStrategy<DecorationItem>>().ToTransient<RandomStrategy<DecorationItem>>();
            Container.Bind<IDecorationGenerator>().ToInstance(_decorationsSettings.Generator);
            Container.Bind<IGeneratingStrategy>().ToInstance(_decorationsSettings.Strategy);
            Container.Bind<IObjectPool<DecorationItem>>().ToSingleGameObject<DecorationPool>("DecorationsPool");
            Container.Bind<bool>(GameObjectPool<DecorationItem>.CAN_GROW_KEY)
                .ToInstance(true)
                .WhenInjectedInto<DecorationPool>();
            Container.Bind<int>(GameObjectPool<DecorationItem>.INITIAL_SIZE_KEY)
                .ToInstance(_initialPoolSize*2)
                .WhenInjectedInto<DecorationPool>();
        }

        private void BindGround() {
            Container.Bind<Engine.Factory.IFactory<GroundBlock>>()
                .ToTransient<RandomGameObjectFactory<GroundBlock>>();
            Container.Bind<RandomGameObjectFactory<GroundBlock>.ISettings>().ToInstance(_blockSettings);
            Container.Bind<IPoolStrategy<GroundBlock>>().ToTransient<CompatibleStrategy<GroundBlock>>();
            Container.Bind<IGroundGenerator>().ToInstance(_blockSettings.Generator);
            Container.Bind<IObjectPool<GroundBlock>>().ToSingleGameObject<GroundPool>("GroundBlocksPool");
            Container.Bind<bool>(GameObjectPool<GroundBlock>.CAN_GROW_KEY)
                .ToInstance(true)
                .WhenInjectedInto<GroundPool>();
            Container.Bind<int>(GameObjectPool<GroundBlock>.INITIAL_SIZE_KEY)
                .ToInstance(_initialPoolSize)
                .WhenInjectedInto<GroundPool>();
        }

        [Serializable]
        public class BlockSettings : RandomGameObjectFactory<GroundBlock>.ISettings {
            [SerializeField]
            private GroundGenerator _generator;

            [SerializeField]
            private GroundBlock[] _prefabs;

            public IGroundGenerator Generator {
                get { return _generator; }
            }

            public IEnumerable<GroundBlock> Prefabs {
                get { return _prefabs; }
            }
        }

        [Serializable]
        public class DecorationsSettings : RandomGameObjectFactory<DecorationItem>.ISettings {
            [SerializeField]
            private DecorationGenerator _generator;

            [SerializeField]
            private DecorationItem[] _prefabs;

            [SerializeField]
            private AbstractStrategy _strategy;

            public AbstractStrategy Strategy {
                get { return _strategy; }
            }

            public IDecorationGenerator Generator {
                get { return _generator; }
            }

            public IEnumerable<DecorationItem> Prefabs {
                get { return _prefabs; }
            }
        }

        [Serializable]
        public class BonusSettings : RandomGameObjectFactory<Bonus>.ISettings {
            [SerializeField]
            private BonusGenerator _generator;

            [SerializeField]
            private Bonus[] _prefabs;

            [SerializeField]
            private AbstractBonusStrategy _strategy;

            public AbstractBonusStrategy Strategy {
                get { return _strategy; }
            }

            public IBonusGenerator Generator {
                get { return _generator; }
            }

            public IEnumerable<Bonus> Prefabs {
                get { return _prefabs; }
            }
        }
    }
}